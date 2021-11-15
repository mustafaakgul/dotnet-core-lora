using Microsoft.AspNetCore.Mvc;
using LoRaWAN.RestAccess.Abstract;
using LoRaWAN.RestAccess.Models;
using LoRaWAN.WebUI.Models.User;

namespace LoRaWAN.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IAccessRest _accessRest;
        private readonly Connection<dynamic> _connModel; 
        
        public UserController(IAccessRest accessRest)
        {
            _accessRest = accessRest;

            _connModel = new Connection<dynamic>()
            {
                Area = "web",
            };
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }
            
            //Ozellesmesi icin metoda baglı
            _connModel.Controller = "users"; //UsersController in midw conler
            _connModel.Action = "create";
            _connModel.Model = registerModel;
            
            var response = _accessRest.PostJSON<dynamic>(_connModel);
            
            /*if (response.Status.Success)
            {
                _connModel.Controller = "Login";
                _connModel.Action = "User";
                _connModel.Model = new LoginCredential { Email = model.Email, Password = model.Password };

                var loginResponse = _accessRest.PostJSON<UserModel, dynamic>(_connModel);

                if (loginResponse.Status.Success)
                {
                    HttpContext.Session.SetObject("User", loginResponse.Content);
                    HttpContext.Session.SetString("isUserLogin", $"{loginResponse.Content.Name} {loginResponse.Content.Surname}");
                    HttpContext.Session.SetString("userType", loginResponse.Content.UserType.ToString());
                }
                return RedirectToAction("Index","Home", new { area = "User" });
            }
            else
            {
                TempData["Message"] = response.Status.Message;
                TempData["Status"] = "error";
                TempData["redirectUrl"] = "";
                return View(model);
            }*/

            return View();
        }
    }
}