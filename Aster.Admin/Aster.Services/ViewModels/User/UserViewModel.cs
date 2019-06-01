

using Aster.Entities;
using System;
using static Aster.Entities.CommonEnum;

namespace Aster.Services.ViewModels.User
{
    /// <summary>
    /// 
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
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
        public int UserType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsLocked { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CreatedTime { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string CreatedByUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ModifiedTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ModifiedByUserName { get; set; }
    }
}
