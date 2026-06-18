using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryManagementSystem.Controllers;

public class BaseController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var isLoginPage = context.RouteData.Values["controller"]?.ToString() == "Account";
        if (!isLoginPage && string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
        {
            context.Result = RedirectToAction("Login", "Account");
        }
        base.OnActionExecuting(context);
    }
}
