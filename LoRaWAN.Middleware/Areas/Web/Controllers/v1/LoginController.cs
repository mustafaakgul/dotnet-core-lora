using Business.Abstract;
using Entities.Models.WebUI.User;
using Microsoft.AspNetCore.Mvc;
using ResponseStates.Models;

namespace Middleware.Areas.Web.Controllers.v1
{
    [Area("web")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[area]/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public ResponseState<UserModel> User([FromBody] LoginModel model) => _loginService.UserLogin(model);
    }
}