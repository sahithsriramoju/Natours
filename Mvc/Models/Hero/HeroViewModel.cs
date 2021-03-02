using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models.Hero
{
    public class HeroViewModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
        public string ImageUrl { get; set; }
    }
}