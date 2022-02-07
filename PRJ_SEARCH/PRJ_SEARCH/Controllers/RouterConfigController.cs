using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PRJ_SEARCH
{
    public class RouterConfigController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["IDNguoiDung"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "TrangChu", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}