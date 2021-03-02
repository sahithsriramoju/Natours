using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models.PopularTours
{
    public class PopularToursItemModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string NoOfDays { get; set; }
        public string SizeOfTour{get;set;}
        public string NoOfTourGuides { get; set; }
        public string Price { get; set; }
        public string AdventureTags { get; set; }
        public string DifficultyTags { get; set; }
        public string ImageUrl { get; set; }
        public string Accomodation { get; set; }
    }
}