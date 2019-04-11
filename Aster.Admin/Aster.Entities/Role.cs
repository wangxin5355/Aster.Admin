using Aster.Common.Data.Core;
using Aster.Common.Data.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Entities
{
    [TableName("role")]
    public class Role: IEntity
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public bool IsDeleted { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        public string CreatedByUserName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedTime { get; set; }

        /// <summary>
        /// 修改人名称
        /// </summary>
        public string ModifiedByUserName { get; set; }

        public bool IsSuperAdministrator { get; set; }

        public bool IsBuiltin { get; set; }
    }
}
