using Aster.Common.Data.Core;
using Aster.Common.Data.Core.Attributes;
using System;

namespace Aster.Entities
{
    //[DataContext("DefaultConnectionString")]默认的就是这个，如果是其他的库。就需要声明
    [TableName("user")]
    public class User: IEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///登陆名称
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        ///显示名称名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        ///密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool  IsLocked { get; set; }


        /// <summary>
        /// 用户状态
        /// </summary>
        public int Status { get; set; }


        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

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

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }



    }
}
