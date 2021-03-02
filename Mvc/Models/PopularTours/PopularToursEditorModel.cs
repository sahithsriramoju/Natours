using SitefinityWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models.PopularTours
{
    public class PopularToursEditorModel
    {
        public string SelectedIds { get; set; }
        public string SelectedItem { get; set; }

       public PopularToursViewModel GetViewModel()
        {
            var service = new TourService();
            var model = new PopularToursViewModel()
            {
                Items = this.SelectedItem,
                Ids = this.SelectedIds,
                PopularToursItems = service.GetItemsBySelectedIds(this.SelectedIds)
            };
            return model;
        } 
    }
}