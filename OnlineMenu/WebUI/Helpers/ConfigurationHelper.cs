using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebUI.Helpers
{
    public class ConfigurationHelper
    {
        public static GlobalizationSection GetGlobalizationSection()
        {
            return WebConfigurationManager.GetSection("system.web/globalization") as GlobalizationSection;
        }
    }
}