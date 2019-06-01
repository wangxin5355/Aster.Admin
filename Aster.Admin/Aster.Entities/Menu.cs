using Aster.Common.Data.Core;
using Aster.Common.Data.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using static Aster.Entities.CommonEnum;

namespace Aster.Entities
{
    [TableName("menu")]
    public class Menu : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }


        public string Icon { get; set; }


        public int ParentId { get; set; }

        public string ParentName { get; set; }

        public int Level { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }


        public bool IsDeleted { get; set; }


        public bool IsDefaultRouter{get;set;}


        public DateTime CreateTime { get; set; }

        public string CreatedByUserName { get; set; }


        public DateTime ModifiedTime { get; set; }

        public string ModifiedByUserName { get; set; }


    }
}
