using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TODO.Filters
{
    public class LoginFilter : ActionFilterAttribute
    {
        private readonly string _logFilePath;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetString("user");

            if (string.IsNullOrEmpty(user))
            {
                context.Result = new RedirectToActionResult("Login", "Login", null);
            }

            var username = context.HttpContext.Session.GetString("user") ?? "Anonyme";
            var controller = context.RouteData.Values["controller"]?.ToString();
            var action = context.RouteData.Values["action"]?.ToString();
            var date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            var logLine = $"{date} - {username} - {controller} - {action}\n";

            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Log.txt");
            File.AppendAllText(logPath, logLine);
        }
    }
}
