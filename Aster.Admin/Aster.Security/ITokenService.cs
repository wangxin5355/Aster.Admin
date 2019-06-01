using Aster.Security.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Security
{
    public interface ITokenService
    {
        /// <summary>
        /// 删除用户的token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="packType"></param>
        /// <returns></returns>
        Task DelToken(int userId, string packType);

        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<(string tokenstr, DateTime expireTime)> BuildToken(TokenInfo token);


        /// <summary>
        /// 获取token信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<TokenInfo> GetTokenInfo(string token);


    }
}
