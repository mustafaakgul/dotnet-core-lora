using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoRaWAN.RestAccess.Abstract;
using LoRaWAN.RestAccess.Models;
using LoRaWAN.WebUI.Models.User;
using LoRaWAN.WebUI.Utilities.Extensions;

namespace LoRaWAN.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccessRest _accessRest;
        private readonly Connection<dynamic> _connModel;

        public LoginController(IAccessRest accessRest)
        {
            _accessRest = accessRest;
            _connModel = new Connection<dynamic>()
            {
                Area = "web",
                Controller = "login"
            };
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginModel);
            }
            //_connModel.Action = "user";
            _connModel.Model = loginModel;

            var response = _accessRest.PostJSON<UserModel, dynamic>(_connModel);
            
            if (response.Status.Success)
            {
                HttpContext.Session.SetObject("User", response.Content);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(loginModel);
            }
        }
        
    }
}