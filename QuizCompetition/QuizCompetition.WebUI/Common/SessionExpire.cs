using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace School.WebUI.SMHS.Common.Filters
{
    public class SessionExpire : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["user"] == null)
            {
                FormsAuthentication.SignOut();
                filterContext.Result =
               new RedirectToRouteResult(new RouteValueDictionary
                 {
             { "action", "LogIn" },
            { "controller", "Login" },
            { "returnUrl", filterContext.HttpContext.Request.RawUrl}
                  });

                return;
            }
        }

    }
}