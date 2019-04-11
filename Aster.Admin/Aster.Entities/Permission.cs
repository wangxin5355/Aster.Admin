using Aster.Common.Data.Core;
using Aster.Common.Data.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Entities
{
    [TableName("permission")]
    public class Permission : IEntity
    {
        public int Id { get; set; }

        public int MenuId { get; set; }

        public string Name { get; set; }

        public string ActionCode { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }


        public int Status { get; set; }

        public bool IsDeleted { get; set; }

        public int Type { get; set; }

        public DateTime CreateTime { get; set; }

        public string CreatedByUserName { get; set; }


        public DateTime ModifiedTime { get; set; }

        public string ModifiedByUserName { get; set; }

    }
}
