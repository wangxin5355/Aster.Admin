

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aster.Services.ViewModels.User
{
    /// <summary>
    /// 用户获得的角色实体对象
    /// </summary>
    public class SaveUserRolesViewModel
    {
        /// <summary>
        /// 用户GUID
        /// </summary>
        public Guid UserGuid { get; set; }
        /// <summary>
        /// 已获得的角色代码集合
        /// </summary>
        public List<string> AssignedRoles { get; set; }
    }
}
