
using Aster.Entities.Models;
using Aster.Services.ViewModels.Menu;
using Aster.Services.ViewModels.Permission;
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
    /// 权限控制器
    /// </summary>
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PermissionController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public PermissionController()
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
        /// 创建权限
        /// </summary>
        /// <param name="model">权限视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Create(PermissionCreateViewModel model)
        {

                return Ok();
            
        }

        /// <summary>
        /// 编辑权限
        /// </summary>
        /// <param name="code">权限惟一编码</param>
        /// <returns></returns>
        [HttpGet("{code}")]
        [ProducesResponseType(200)]
        public IActionResult Edit(string code)
        {

             return Ok();
            
        }

        /// <summary>
        /// 保存编辑后的权限信息
        /// </summary>
        /// <param name="model">权限视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Edit(PermissionEditViewModel model)
        {

                return Ok();
            
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="ids">权限ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(string ids)
        {

            return Ok();
        }

        /// <summary>
        /// 恢复权限
        /// </summary>
        /// <param name="ids">权限ID,多个以逗号分隔</param>
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
        /// <param name="ids">权限ID,多个以逗号分隔</param>
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
        /// 角色-权限菜单树
        /// </summary>
        /// <param name="code">角色编码</param>
        /// <returns></returns>
        [HttpGet("/api/v1/permission/permission_tree/{code}")]
        public IActionResult PermissionTree(string code)
        {

//            using (_dbContext)
//            {
//                var role = _dbContext.DncRole.FirstOrDefault(x => x.Code == code);
//                if (role == null)
//                {
//                    response.SetFailed("角色不存在");
//                    return Ok(response);
//                }
//                var menu = _dbContext.DncMenu.Where(x => x.IsDeleted == IsDeleted.No && x.Status == Status.Normal).OrderBy(x => x.CreatedOn).ThenBy(x => x.Sort)
//                    .Select(x => new PermissionMenuTree
//                    {
//                        Guid = x.Guid,
//                        ParentGuid = x.ParentGuid,
//                        Title = x.Name
//                    }).ToList();
//                //DncPermissionWithAssignProperty
//                var sql = @"SELECT P.Code,P.MenuGuid,P.Name,P.ActionCode,ISNULL(S.RoleCode,'') AS RoleCode,(CASE WHEN S.PermissionCode IS NOT NULL THEN 1 ELSE 0 END) AS IsAssigned FROM DncPermission AS P 
//LEFT JOIN (SELECT * FROM DncRolePermissionMapping AS RPM WHERE RPM.RoleCode={0}) AS S 
//ON S.PermissionCode= P.Code
//WHERE P.IsDeleted=0 AND P.Status=1";
//                if (role.IsSuperAdministrator)
//                {
//                    sql = @"SELECT P.Code,P.MenuGuid,P.Name,P.ActionCode,'SUPERADM' AS RoleCode,(CASE WHEN P.Code IS NOT NULL THEN 1 ELSE 0 END) AS IsAssigned FROM DncPermission AS P 
//WHERE P.IsDeleted=0 AND P.Status=1";
//                }
//                var permissionList = _dbContext.DncPermissionWithAssignProperty.FromSql(sql, code).ToList();
//                var tree = menu.FillRecursive(permissionList, Guid.Empty, role.IsSuperAdministrator);
//                response.SetData(new { tree, selectedPermissions = permissionList.Where(x => x.IsAssigned == 1).Select(x => x.Code) });
//            }

            return Ok();
        }


    }


    /// <summary>
    /// 
    /// </summary>
    public static class PermissionTreeHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menus">菜单集合</param>
        /// <param name="permissions">权限集合</param>
        /// <param name="parentGuid">父级菜单GUID</param>
        /// <param name="isSuperAdministrator">是否为超级管理员角色</param>
        /// <returns></returns>
        public static List<PermissionMenuTree> FillRecursive(this List<PermissionMenuTree> menus, List<PermissionWithAssignProperty> permissions, Guid? parentGuid, bool isSuperAdministrator = false)
        {
            List<PermissionMenuTree> recursiveObjects = new List<PermissionMenuTree>();
            foreach (var item in menus.Where(x => x.ParentGuid == parentGuid))
            {
                var children = new PermissionMenuTree
                {
                    AllAssigned = isSuperAdministrator ? true : (permissions.Where(x => x.MenuGuid == item.Guid).Count(x => x.IsAssigned == 0) == 0),
                    Expand = true,
                    Guid = item.Guid,
                    ParentGuid = item.ParentGuid,
                    Permissions = permissions.Where(x => x.MenuGuid == item.Guid).Select(x => new PermissionElement
                    {
                        Name = x.Name,
                        Code = x.Code,
                        IsAssignedToRole = IsAssigned(x.IsAssigned, isSuperAdministrator)
                    }).ToList(),

                    Title = item.Title,
                    Children = FillRecursive(menus, permissions, item.Guid)
                };
                recursiveObjects.Add(children);
            }
            return recursiveObjects;
        }

        private static bool IsAssigned(int isAssigned, bool isSuperAdministrator)
        {
            if (isSuperAdministrator)
            {
                return true;
            }
            return isAssigned == 1;
        }

        //public static List<PermissionMenuTree> FillRecursive(this List<PermissionMenuTree> menus, List<DncPermissionWithAssignProperty> permissions, Guid? parentGuid)
        //{
        //    List<PermissionMenuTree> recursiveObjects = new List<PermissionMenuTree>();

        //    return recursiveObjects;
        //}
    }
}