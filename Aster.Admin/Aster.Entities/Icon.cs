using Aster.Common.Data.Core;
using Aster.Common.Data.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Entities
{
    [TableName("icon")]
    public class Icon: IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// 图片代码
        /// </summary>
        public string Code { get; set; }


        /// <summary>
        /// 尺寸
        /// </summary>
        public string Size { get; set; }


        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }


        public string Custom { get; set; }


        public string Description { get; set; }

        public int Status { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateTime { get; set; }

        public string CreatedByUserName { get; set; }


        public DateTime ModifiedTime { get; set; }

        public string ModifiedByUserName { get; set; }


    }
}
