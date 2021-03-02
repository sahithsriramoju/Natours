using SitefinityWebApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models.Hero
{
    public class HeroEditorModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
        public Guid ImageId { get; set; }
        public HeroViewModel GetViewModel()
        {
            var image= this.ImageId.GetImage();
            var viewModel = new HeroViewModel()
            {
                Title = this.Title,
                Subtitle = this.Subtitle,
                ButtonText = this.ButtonText,
                ButtonLink = this.ButtonLink,
                ImageUrl = image != null ? image.Url : string.Empty
            };
            return viewModel;
        }
    }
}