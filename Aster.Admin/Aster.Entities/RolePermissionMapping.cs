using Aster.Common.Data.Core;
using Aster.Common.Data.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Entities
{
    [TableName("rolepermissionmapping")]
    public class RolePermissionMapping: IEntity
    {
        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
