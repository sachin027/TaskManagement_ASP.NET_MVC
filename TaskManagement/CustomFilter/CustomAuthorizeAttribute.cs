
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;


namespace TaskManagement.CustomFilter
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if(SessionHelper.SessionHelper.Username!= "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "LoginSignup" },
                    { "action", "Index" }
               });
        }
    }
}
