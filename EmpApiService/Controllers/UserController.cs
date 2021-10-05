using EmpApiService.Models.Request;
using EmpApiService.Models.Response;
using EmpApiService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpApiService.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsersAsync()
        {
            try
            {
                List<User> response = await userService.GetUsersAsync().ConfigureAwait(false);
                return Ok(new APIResponse() { IsError = false, ApiResult = response });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { IsError = true, ErrorMessage = ex.Message.ToString() });
            }
        }

        [HttpPost]
        [Route("NewUser")]
        public async Task<IActionResult> NewUserAsync([FromBody] User user)
        {
            try
            {
                bool response = await userService.NewUserAsync(user).ConfigureAwait(false);
                return Ok(new APIResponse() { IsError = false, ApiResult = response });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { IsError = true, ErrorMessage = ex.Message.ToString() });
            }
        }

        [HttpGet]
        [Route("IsUserExist/{emailId}")]
        public async Task<IActionResult> IsUserExistAsync([FromRoute] string emailId)
        {
            try
            {
                bool response = await userService.IsUserExistAsync(emailId).ConfigureAwait(false);
                return Ok(new APIResponse() { IsError = false, ApiResult = response });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { IsError = true, ErrorMessage = ex.Message.ToString() });
            }
        }
    }
}
