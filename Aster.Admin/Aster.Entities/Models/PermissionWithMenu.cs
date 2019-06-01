﻿using System;
using System.Collections.Generic;
using System.Text;
using static Aster.Entities.CommonEnum;

namespace Aster.Entities.Models
{
    /// <summary>
    /// 权限菜单实体
    /// </summary>
    public class PermissionWithMenu
    {
        /// <summary>
        /// 权限Id
        /// </summary>
        public string PermissionId { get; set; }
        /// <summary>
        /// 权限操作码
        /// </summary>
        public string PermissionActionCode { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermissionName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public PermissionType PermissionType { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单Id
        /// </summary>
        public int MenuId{ get; set; }
        /// <summary>
        /// 菜单别名(与前端路由配置中的name值保持一致)
        /// </summary>
        public string MenuAlias { get; set; }
        /// <summary>
        /// 是否是默认前端路由
        /// </summary>
        public bool IsDefaultRouter { get; set; }
    }
}
