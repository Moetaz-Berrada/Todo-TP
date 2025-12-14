using Microsoft.AspNetCore.Mvc;

namespace TODO.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Switch(string theme)
        {
            if (theme == "dark" || theme == "light")
            {
                Response.Cookies.Append(
                    "theme",
                    theme,
                    new CookieOptions()
                );
            }

            string returnUrl = Request.Headers["Referer"].ToString();
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Todo");
            }
            return Redirect(returnUrl);
        }
    }
}
