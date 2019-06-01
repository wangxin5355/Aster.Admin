using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Aster.Cache;
using Aster.Common.Utils;
using Aster.Security.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Aster.Security
{
    public class TokenService : ITokenService
    {
        private const string _user_token_cache = "user.{0}.{1}";
        private readonly IDistributedCache _distributedCache;
        private readonly TokenOptions _tokenOptions;

        public TokenService( IOptions<TokenOptions> tokenOptions,
            IDistributedCache distributedCache)
        {
            _tokenOptions = tokenOptions.Value;
            _distributedCache = distributedCache;
        }

        public async Task<(string tokenstr,DateTime expireTime)> BuildToken(TokenInfo tokenInfo)
        {
            tokenInfo.PackType = tokenInfo.PackType.ToLowerInvariant();
            TimeSpan? expireIn = GetExpireIn(tokenInfo.PackType);
            //过期时间写入token
      
            long expireTimeSpan = DateTimeUtil.GetTimestamps(DateTime.Now);
            tokenInfo.ExpireTime = expireIn.HasValue ? (int)expireIn.Value.TotalMilliseconds+ expireTimeSpan : -1;
            DateTime expireRime = DateTimeUtil.FromTimestamps(tokenInfo.ExpireTime);
            string key = string.Format(_user_token_cache, tokenInfo.UserId, tokenInfo.PackType);
            var tokenstr = SecurityUtil.AESEncrypt(key);
            var claimsIdentity = new ClaimsIdentity(new Claim[]
             {
                    new Claim(ClaimTypes.Name, tokenInfo.UserName),
                    new Claim(ClaimTypes.NameIdentifier, tokenInfo.UserId.ToString()),
                    new Claim("isAdmin",tokenInfo.IsAdmin.ToString()),
                    new Claim("displayName",tokenInfo.DisplyName),
                    new Claim("loginName",tokenInfo.UserName),
                    new Claim("emailAddress",""),
                    new Claim("packType",tokenInfo.PackType)
             });
            //var token = JwtBearerAuthenticationExtension.GetJwtAccessToken(_tokenOptions, claimsIdentity, expireIn);
            tokenInfo.TokenIdentity = tokenstr;
            await _distributedCache.SetSlidingExpiration(key, tokenInfo, expireIn);
            return (tokenstr, expireRime);
        }



        private TimeSpan? GetExpireIn(string loginType)
        {
            if (_tokenOptions.Expires != null)
            {
                var expire = _tokenOptions.Expires
                    .FirstOrDefault(x => x.LoginType.Equals(loginType, StringComparison.InvariantCultureIgnoreCase));

                if (expire != null)
                    return expire.ExpireTime;
            }

            return _tokenOptions.TokenExpireTime;
        }


        public async Task DelToken(int userId, string packType)
        {
            if (userId <= 0)
                return;

            if (string.IsNullOrWhiteSpace(packType))
                throw new ArgumentNullException(packType);

            packType = packType.ToLowerInvariant();
            string key = string.Format(_user_token_cache, userId, packType);

            await _distributedCache.RemoveAsync(key);
        }

        public async Task<TokenInfo> GetTokenInfo(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException(nameof(token));

            string json = await _distributedCache.GetStringAsync(token);

            if (string.IsNullOrWhiteSpace(json)) return null;

            return JsonConvert.DeserializeObject<TokenInfo>(json);
        }
    }
}
