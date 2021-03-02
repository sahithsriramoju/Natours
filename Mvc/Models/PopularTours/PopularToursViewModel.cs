using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models.PopularTours
{
    public class PopularToursViewModel
    {
        public List<PopularToursItemModel> PopularToursItems { get; set; }
        public string Items { get; set; }
        public string Ids { get; set; }
    }
}