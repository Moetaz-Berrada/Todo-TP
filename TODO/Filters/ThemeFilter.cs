using Microsoft.AspNetCore.Mvc.Filters;

namespace TODO.Filters
{
    public class ThemeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var theme = context.HttpContext.Request.Cookies["theme"];

            if (string.IsNullOrEmpty(theme))
            {
                theme = "light";
            }

            var controller = context.Controller as Microsoft.AspNetCore.Mvc.Controller;
            if (controller != null)
            {
                controller.ViewBag.Theme = theme;
            }

            base.OnActionExecuting(context);
        }
    }
}
