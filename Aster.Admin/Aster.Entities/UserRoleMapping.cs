using Aster.Common.Data.Core;
using Aster.Common.Data.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Entities
{
    [TableName("userrolemapping")]
    public class UserRoleMapping: IEntity
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedTime { get; set; }

    }
}
