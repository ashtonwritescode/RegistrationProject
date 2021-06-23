using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationProject.Helpers
{
    public static class DisplayCountries
    {
        public static IEnumerable<SelectListItem> GetCountryList()
        {
            IList<SelectListItem> countries = new List<SelectListItem>
            {
                new SelectListItem() { Text = "United States", Value = "US"}
            };

            return countries;
        }
    }
}