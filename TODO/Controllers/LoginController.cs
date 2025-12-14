using Microsoft.AspNetCore.Mvc;
using TODO.Models;
using TODO.Services;
using TODO.ViewModels;

namespace TODO.Controllers
{
    public class LoginController : Controller
    {
        ISessionManagerService session;
        public LoginController(ISessionManagerService session)
        {
            this.session = session;
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                return RedirectToAction("Index", "Todo");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (vm.Username == "admin" && vm.Password == "1234")
            {
                var user = new Login
                {
                    Username = vm.Username,
                    Password = vm.Password
                };

                HttpContext.Session.SetString("user", vm.Username);
                session.Add("currentUser", user, HttpContext);

                return RedirectToAction("Index", "Todo");
            }
            else
            {
                ModelState.AddModelError("", "Nom d'utilisateur ou mot de passe est incorrect");
                return View();
            }
        }
        public IActionResult Logout()
        {
            var username = HttpContext.Session.GetString("user");

            if (!string.IsNullOrEmpty(username))
            {
                HttpContext.Session.SetString("lastUser", username);
            }

            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
