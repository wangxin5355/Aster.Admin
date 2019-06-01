using Aster.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Services.Models
{
    public class UserPagePermissions
    {
        public string[] Access { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string Avator { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public int UserType { get; set; }

        /// <summary>
        /// 允许访问的页面
        /// </summary>
        public List<string> Pages { get; set; }

        public Dictionary<string ,List<string>> PagePermissions { get; set; }
    }
}
