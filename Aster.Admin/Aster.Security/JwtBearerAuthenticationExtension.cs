

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aster.Security.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Aster.Security
{
    /// <summary>
    /// 
    /// </summary>
    public static class JwtBearerAuthenticationExtension
    {
        /// <summary>
        /// 注册JWT Bearer认证服务的静态扩展方法
        /// </summary>
        /// <param name="services"></param>
        /// <param name="appSettings">JWT授权的配置项</param>
        public static void AddJwtBearerAuthentication(this IServiceCollection services, TokenOptions tokenOptions)
        {
            //使用应用密钥得到一个加密密钥字节数组
            var key = Encoding.ASCII.GetBytes(tokenOptions.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(cfg => cfg.SlidingExpiration = true)
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static string GetJwtAccessToken(TokenOptions tokenOptions, ClaimsIdentity claimsIdentity, TimeSpan? expireIn)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            int expires = expireIn.HasValue ? (int)expireIn.Value.TotalSeconds  : -1;
            var key = Encoding.ASCII.GetBytes(tokenOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddSeconds(expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
