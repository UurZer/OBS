using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OBS.Business.LoginManager;

namespace OBS.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginManager _login;
        public LoginController(ILoginManager login)
        {
            _login = login;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string UserName,string Password)
        {
            if(_login.IsLoginSuccess(UserName, Password))
            {
                
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
