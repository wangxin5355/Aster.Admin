using Aster.Entities;
using System;

namespace Aster.Security.Models
{
    public class TokenInfo
    {
        public TokenInfo(User user)
        {
            UserId = user.Id;
            UserName = user.LoginName;
            IsAdmin = true;
            DisplyName = user.DisplayName;
        }

        public string PackType { get; set; }

        public bool IsAdmin { get; set; }

        /// <summary>
        /// token唯一标识
        /// </summary>
        public string TokenIdentity { get; set; }

        public int UserId { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public int ExpireIn { get; set; }

        public string Code { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplyName { get; set; }

        /// <summary>
        /// 注册类型
        /// </summary>
        public string RegistType { get; set; }

        /// <summary>
        /// 激活时间
        /// </summary>
        public DateTime? ActivedTime { get; set; }

        /// <summary>
        /// 最后一次修改密码的时间
        /// </summary>
        public DateTime? LastModifiedPwdTime { get; set; }

        /// <summary>
        /// 最后一次禁用google二次验证的时间
        /// </summary>
        public DateTime? LastDisableTwoFactoriesTime { get; set; }

        /// <summary>
        /// 账号是否有效
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// 是否允许提现
        /// </summary>
        public bool AllowWithdraw { get; set; }

        /// <summary>
        /// 是否允许交易
        /// </summary>
        public bool AllowTrade { get; set; }

        /// <summary>
        /// 仓位上限模板ID
        /// </summary>
        public int PositionLimitTemplateId { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public long ExpireTime { get; set; }


    }
}
