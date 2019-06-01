
using Aster.Common.Models;
using Aster.Services;
using Aster.Services.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Aster.Admin.API.Controllers.Api.V1
{
    /// <summary>
    /// 
    /// </summary>
    //[CustomAuthorize]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> List([FromQuery]UserSearchViewModel search, int page = 1, int limit = 20)
        {
            var p = await _userService.Search(search, new Pager(page, limit));
            var ls = new ListResultViewModel<UserViewModel>(p);
            return Ok(ls);

        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="model">用户视图实体</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            await _userService.Create(model);
            return Ok();

        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="guid">用户GUID</param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(200)]
        public IActionResult Edit(int userId)
        {
                return Ok();
        }

        /// <summary>
        /// 保存编辑后的用户信息
        /// </summary>
        /// <param name="model">用户视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Edit(UserEditViewModel model)
        {
            return Ok();
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ids">用户GUID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(string ids)
        {

            return Ok();
        }

        /// <summary>
        /// 恢复用户
        /// </summary>
        /// <param name="ids">用户GUID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Recover(string ids)
        {
            return Ok();
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ids">用户ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Batch(string command, string ids)
        {

            switch (command)
            {
                case "delete":

                    break;
                case "recover":

                    break;
                case "forbidden":


                    break;
                case "normal":

                    break;
                default:
                    break;
            }
            return Ok();
        }

        #region 用户-角色
        /// <summary>
        /// 保存用户-角色的关系映射数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/v1/user/save_roles")]
        public IActionResult SaveRoles(SaveUserRolesViewModel model)
        {

            return Ok();
        }
        #endregion



    }
}