﻿


using Aster.Entities;
using System;
using static Aster.Entities.CommonEnum;

namespace Aster.Admin.API.ViewModels.User
{
    /// <summary>
    /// 
    /// </summary>
    public class UserCreateViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public UserType UserType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IsLocked IsLocked { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public UserStatus Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 用户描述信息
        /// </summary>
        public string Description { get; set; }
    }
}
