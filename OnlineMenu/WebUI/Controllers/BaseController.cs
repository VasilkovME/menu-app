using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var globalizationHelper = new GlobalizationHelper(this.HttpContext);
            
            var culture = globalizationHelper.GetCurrentUserCulture();

            if (culture == null) {
                var defaultCulture = globalizationHelper.GetDefaultUICulture();
                culture = globalizationHelper.AssignCultureToCurrentUser(defaultCulture);
            }

            globalizationHelper.SetThreadCulture(culture);

            ViewBag.AvailableCultures = GlobalizationHelper.GetAvailableCultures();

            base.OnActionExecuting(filterContext);
        }
    }
}