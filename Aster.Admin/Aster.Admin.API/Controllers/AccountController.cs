
using Aster.Common.Data.Core.Repositories;
using Aster.Common.Extensions;
using Aster.Entities;
using Aster.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Aster.Entities.CommonEnum;

namespace DncZeus.Api.Controllers
{
    /// <summary>
    /// 获取账号权限相关的
    /// </summary>
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountService"></param>
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async  Task<IActionResult> Profile()
        {
           var UserID= this.User.GetId();

            var result = await _accountService.GetUserPagePermissions(UserID);

            return Ok(result);
        }


    }
}