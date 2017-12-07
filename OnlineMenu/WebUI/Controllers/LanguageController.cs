using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class LanguageController : Controller
    {
        public ActionResult Change(string language, string returnUrl)
        {
            var culture = new CultureInfo(language);

            var globalizationHelper = new GlobalizationHelper(this.HttpContext);
            globalizationHelper.AssignCultureToCurrentUser(culture);

            return Redirect(returnUrl);
        }
    }
}