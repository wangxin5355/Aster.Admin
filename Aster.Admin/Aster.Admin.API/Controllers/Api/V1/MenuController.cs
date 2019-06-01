
using Aster.Services.ViewModels.Menu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Aster.Admin.API.Controllers.Api.V1.Rbac
{
    /// <summary>
    /// 
    /// </summary>
    //[CustomAuthorize]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {

        public MenuController()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult List([FromQuery]MenuSearchViewModel search, int page = 1, int limit = 20)
        {

                return Ok();
            
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="model">菜单视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Create(MenuCreateViewModel model)
        {

                return Ok();
            
        }

        /// <summary>
        /// 编辑菜单
        /// </summary>
        /// <param name="guid">菜单ID</param>
        /// <returns></returns>
        [HttpGet("{guid}")]
        [ProducesResponseType(200)]
        public IActionResult Edit(Guid guid)
        {

                return Ok();
            
        }

        /// <summary>
        /// 保存编辑后的菜单信息
        /// </summary>
        /// <param name="model">菜单视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Edit(MenuEditViewModel model)
        {

                return Ok();
            
        }

        /// <summary>
        /// 菜单树
        /// </summary>
        /// <returns></returns>
        [HttpGet("{selected?}")]
        public IActionResult Tree(string selected)
        {

            //var tree = LoadMenuTree(selected?.ToString());
          
            return Ok();
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="ids">菜单ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(string ids)
        {

            return Ok();
        }

        /// <summary>
        /// 恢复菜单
        /// </summary>
        /// <param name="ids">菜单ID,多个以逗号分隔</param>
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
        /// <param name="ids">菜单ID,多个以逗号分隔</param>
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


        //private List<MenuTree> LoadMenuTree(string selectedGuid = null)
        //{
        //    var temp = _dbContext.DncMenu.Where(x => x.IsDeleted == CommonEnum.IsDeleted.No && x.Status == CommonEnum.Status.Normal).ToList().Select(x => new MenuTree
        //    {
        //        Guid = x.Guid.ToString(),
        //        ParentGuid = x.ParentGuid,
        //        Title = x.Name
        //    }).ToList();
        //    var root = new MenuTree
        //    {
        //        Title = "顶级菜单",
        //        Guid = Guid.Empty.ToString(),
        //        ParentGuid = null
        //    };
        //    temp.Insert(0, root);
        //    var tree = temp.BuildTree(selectedGuid);
        //    return tree;
        //}
    }

    /// <summary>
    /// 
    /// </summary>
    public static class MenuTreeHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menus"></param>
        /// <param name="selectedGuid"></param>
        /// <returns></returns>
        public static List<MenuTree> BuildTree(this List<MenuTree> menus, string selectedGuid = null)
        {
            var lookup = menus.ToLookup(x => x.ParentGuid);
            Func<Guid?, List<MenuTree>> build = null;
            build = pid =>
            {
                return lookup[pid]
                 .Select(x => new MenuTree()
                 {
                     Guid = x.Guid,
                     ParentGuid = x.ParentGuid,
                     Title = x.Title,
                     Expand = (x.ParentGuid == null || x.ParentGuid == Guid.Empty),
                     Selected = selectedGuid == x.Guid,
                     Children = build(new Guid(x.Guid)),
                 })
                 .ToList();
            };
            var result = build(null);
            return result;
        }
    }
}