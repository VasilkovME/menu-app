using System;
using System.Collections.Generic;
using System.Linq;
using Resources.UI;
using System.Reflection;
using System.Globalization;
using WebUI.Models;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace WebUI.Helpers
{
    public static class ViewsHelper
    {
        public static Dictionary<string, string> GetGlobalResources()
        {
            var dictianary = new Dictionary<string, string>();

            var globalResourceType = typeof(Global);
            var properties = globalResourceType.GetProperties().Cast<PropertyInfo>();
            var currentCulture = CultureInfo.CurrentUICulture;

            var resourceManager = Global.ResourceManager;

            foreach (var property in properties)
            {
                var resourceName = property.Name;
                var resourceValue = resourceManager.GetString(resourceName, currentCulture);

                dictianary.Add(resourceName, resourceValue);
            }

            return dictianary;
        }

        public static List<NavBarItem> GetNavBarItems()
        {
            var list = new List<NavBarItem>();
            var currentController = HttpContext.Current.Request.RequestContext
                                               .RouteData.Values["controller"].ToString();

            list.Add(new NavBarItem
            {
                Action = "Index",
                Controller = "Home",
                IsActive = currentController.Equals("Home", StringComparison.OrdinalIgnoreCase),
                Title = Global.Home
            });

            list.Add(new NavBarItem
            {
                Action = "Index",
                Controller = "Ingredient",
                IsActive = currentController.Equals("Ingredient", StringComparison.OrdinalIgnoreCase),
                Title = Global.Ingredients
            });

            list.Add(new NavBarItem
            {
                Action = "Index",
                Controller = "Food",
                IsActive = currentController.Equals("Food", StringComparison.OrdinalIgnoreCase),
                Title = Global.Food
            });

            //list.Add(new NavBarItem
            //{
            //    Action = "Index",
            //    Controller = "Menu",
            //    IsActive = currentController.Equals("Menu", StringComparison.OrdinalIgnoreCase),
            //    Title = Global.Menus
            //});

            return list;
        }

        public static List<SelectListItem> SelectListItemsFromEnum(Type enumType)
        {
            var values = Enum.GetValues(enumType);
            var list = new List<SelectListItem>();

            foreach (var item in values)
            {
                var intValue = (int)item;
                list.Add(new SelectListItem { Text = item.ToString(), Value = intValue.ToString() });
            }

            return list;
        }

        public static List<SelectListItem> SelectListItemsFromCollection(IEnumerable<string> options, string selectedValue)
        {
            var list = new List<SelectListItem>();

            foreach (var item in options)
            {
                list.Add(new SelectListItem { Text = item.ToString(), Value = item, Selected = (item == selectedValue) });
            }

            return list;
        }

        public static string AvailableLanguagesJson()
        {
            var cultures = GlobalizationHelper.GetAvailableCultures()
                                             .Select(c=>new LanguageViewModel
                                             {
                                                 LanguageName = c.TwoLetterISOLanguageName,
                                                 CultureName = c.Name
                                             }).ToList();

            using (var ms = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(List<LanguageViewModel>));
                serializer.WriteObject(ms, cultures);

                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}