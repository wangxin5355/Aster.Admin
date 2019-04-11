
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Security.Claims;
using Aster.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Aster.Admin.API.ViewModels.Icon;
using Aster.Admin.API.ViewModels.Menu;

namespace DncZeus.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OauthController : ControllerBase
    {
        private readonly IUserService _userService;


        public OauthController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="packType"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Auth(string username, string password,string packType)
        {
            var result = await _userService.Login(username, password, packType);
            var user = User;
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Values()
        {
            var value = new { vaulue1 = 1, vulue2 = 2 };
            return Ok(value);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValuesA(IconCreateViewModel x)
        {
            var value = new { vaulue1 = 1, vulue2 = 2 };
            return Ok(value);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValuesB()
        {
            MenuCreateViewModel menuCreateViewModel = new MenuCreateViewModel();
            return Ok(menuCreateViewModel);
        }
    }
}