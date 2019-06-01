using Aster.Common.Models;
using Aster.Services.Models;
using Aster.Services.ViewModels.User;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aster.Services
{
    public interface IUserService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="packType">平台类型ios androd,pcweb</param>
        /// <returns></returns>
        Task<LoginRpsModel> Login(string userName, string password, string packType);

        Task<Pagination<UserViewModel>> Search(UserSearchViewModel seach, Pager pager);

        Task Create(UserCreateViewModel model);
    }
}
