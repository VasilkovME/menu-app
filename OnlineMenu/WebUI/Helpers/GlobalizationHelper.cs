using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebUI.Helpers
{
    public class GlobalizationHelper
    {
        static string languageCookieName = "userCulture";
        HttpContextBase _context;

        public GlobalizationHelper(HttpContextBase context)
        {
            _context = context;
        }

        public CultureInfo AssignCultureToCurrentUser(CultureInfo culture)
        {
            if (culture == null)
            {
                culture = GetDefaultUICulture();
            }

            var langCookie = new HttpCookie(languageCookieName, culture.Name) { Expires = DateTime.Now.AddDays(7) };
            _context.Response.Cookies.Add(langCookie);

            return culture;
        }

        public void SetThreadCulture(CultureInfo culture)
        {
            if (culture == null) {
                culture = GetDefaultUICulture();
            }

            //change current culture values for the thread
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        public static List<CultureInfo> GetAvailableCultures()
        {
            return new List<CultureInfo> { new CultureInfo("ru-RU"), new CultureInfo("en-US") };
        }

        public CultureInfo GetCurrentUserCulture()
        {
            var langCookie = _context.Request.Cookies[languageCookieName];

            if (langCookie != null) {
                return new CultureInfo(langCookie.Value);
            }

            return null;
        }
        
        public CultureInfo GetDefaultUICulture()
        {
            var section = ConfigurationHelper.GetGlobalizationSection();
            var cultureName = section.UICulture;
            return new CultureInfo(cultureName);
        }
    }
}