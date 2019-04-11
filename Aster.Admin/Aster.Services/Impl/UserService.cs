using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Aster.Common.Data.Core.Repositories;
using Aster.Common.Exceptions;
using Aster.Entities;
using Aster.Security.Models;
using Aster.Services.Models;
using Microsoft.Extensions.Localization;
using static Aster.Entities.CommonEnum;

namespace Aster.Services.Impl
{
    public class UserService : IUserService
    {

        private readonly IStringLocalizer _localizer;
        private readonly IRepository<User> _userRepository;
        private readonly string _cahce_user_info = "user_info1_{0}";
        private readonly string _cache_user_last10_login = "user_last_login_{0}";
        private readonly string _cache_user_setting = "user_setting_{0}";
        private readonly ITokenService _tokenService;

        public UserService(IStringLocalizer<UserService> localizer, IRepository<User> userRepository, ITokenService tokenService)
        {
            _localizer = localizer;
            _userRepository = userRepository;
            _tokenService = tokenService;

        }

        public async Task<LoginRpsModel> Login(string userName, string password, string packType)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new MyException("用户名不能为空");
            if (string.IsNullOrWhiteSpace(password)) throw new MyException("密码不能为空");
            if (string.IsNullOrWhiteSpace(packType)) throw new MyException("packType不能为空");
            var user = await _userRepository.Query(x=>x.LoginName== userName).FirstOrDefaultAsync();
            if (user == null|| user.IsDeleted) throw new MyException("用户名不存在");
            //检查登录次数

            //检查密码
            if (user.PassWord != password.Trim())
            {
                throw new MyException("密码不正确");
            }
            if (user.IsLocked)
            {
                throw new MyException("账号已被锁定");
            }
            if (user.Status == (int)UserStatus.Forbidden)
            {
                throw new MyException("账号已被禁用");
            }
            var rm = new LoginRpsModel()
            {
                UserId = user.Id,
                UserName = user.LoginName,
                Token = null
            };
            await _tokenService.DelToken(user.Id, packType);
            rm.Token = await _tokenService.BuildToken(new TokenInfo(user) { PackType= packType });
            return rm;
        }
    }
}
