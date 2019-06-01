

using System;
using System.Data.SqlClient;
using System.Linq;
using Aster.Services.ViewModels.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aster.Admin.API.Controllers.Api.V1
{
    /// <summary>
    /// 
    /// </summary>
    //[CustomAuthorize]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {


        public RoleController()
        {
;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult List([FromQuery] RoleSearchViewModel search, int page = 1, int limit = 20)
        {
            return Ok();

        }


        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="model">角色视图实体</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(RoleCreateViewModel model)
        {

                return Ok();
            
        }



        /// <summary>
        /// 保存编辑后的角色信息
        /// </summary>
        /// <param name="model">角色视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Edit(RoleCreateViewModel model)
        {

           return Ok();
            
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="ids">角色ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(string ids)
        {

            return Ok();
        }

        /// <summary>
        /// 恢复角色
        /// </summary>
        /// <param name="ids">角色ID,多个以逗号分隔</param>
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
        /// <param name="ids">角色ID,多个以逗号分隔</param>
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

        /// <summary>
        /// 为指定角色分配权限
        /// </summary>
        /// <param name="payload">角色分配权限的请求载体类</param>
        /// <returns></returns>
        [HttpPost("/api/v1/role/assign_permission")]
        public IActionResult AssignPermission()
        {
           
            return Ok();
        }

        /// <summary>
        /// 获取指定用户的角色列表
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FindListByUserGuid(int userId)
        {

                return Ok();
            
        }

        /// <summary>
        /// 查询所有角色列表(只包含主要的字段信息:name,code)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FindSimpleList()
        {

            return Ok();
        }


    }
}