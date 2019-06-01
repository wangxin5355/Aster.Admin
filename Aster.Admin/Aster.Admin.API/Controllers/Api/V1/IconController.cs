

using Aster.Services.ViewModels.Icon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Aster.Admin.API.Controllers.Api.V1.Rbac
{
    /// <summary>
    /// 
    /// </summary>
    //[CustomAuthorize]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class IconController : ControllerBase
    {


        public IconController()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult List([FromQuery]IconSearchViewModel search, int page = 1, int limit = 20)
        {

                return Ok();
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FindByKeyword(string kw)
        {
 
                return Ok();
            
        }

        /// <summary>
        /// 创建图标
        /// </summary>
        /// <param name="model">图标视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Create(IconCreateViewModel model)
        {
           
                return Ok();
            
        }

        /// <summary>
        /// 编辑图标
        /// </summary>
        /// <param name="id">图标ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Edit(int id)
        {


                return Ok();
            
        }

        /// <summary>
        /// 保存编辑后的图标信息
        /// </summary>
        /// <param name="model">图标视图实体</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Edit(IconCreateViewModel model)
        {

                return Ok();
            
        }

        /// <summary>
        /// 删除图标
        /// </summary>
        /// <param name="ids">图标ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(string ids)
        {
            return Ok();
        }

        /// <summary>
        /// 恢复图标
        /// </summary>
        /// <param name="ids">图标ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Recover(string ids)
        {
            return Ok();
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ids">图标ID,多个以逗号分隔</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Batch(string command, string ids)
        {
            switch (command)
            {
                case "delete":

                    break;
                case "recover":
                    break;
                case "forbidden":
                    break;
                case "normal":
                    break;
                default:
                    break;
            }
            return Ok();
        }

        /// <summary>
        /// 创建图标
        /// </summary>
        /// <param name="model">多行图标视图</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Import(IconImportViewModel model)
        {

                return Ok();
            
        }

    }
}