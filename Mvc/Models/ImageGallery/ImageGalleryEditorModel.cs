using SitefinityWebApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models.ImageGallery
{
    public class ImageGalleryEditorModel
    {
        public Guid ImageId1 { get; set; }
        public Guid ImageId2 { get; set; }
        public Guid ImageId3 { get; set; }
        public Guid ImageLargeId1 { get; set; }
        public Guid ImageLargeId2 { get; set; }
        public Guid ImageLargeId3 { get; set; }
        public ImageGalleryViewModel GetViewModel()
        {
            var image1 = this.ImageId1.GetImage();
            var image2 = this.ImageId2.GetImage();
            var image3 = this.ImageId3.GetImage();
            var imageLarge1 = this.ImageLargeId1.GetImage();
            var imageLarge2 = this.ImageLargeId2.GetImage();
            var imageLarge3 = this.ImageLargeId3.GetImage();
            var viewModel = new ImageGalleryViewModel()
            {
                ImageUrl1 = image1 != null ? image1.Url : string.Empty,
                ImageUrl2 = image2 != null ? image2.Url : string.Empty,
                ImageUrl3 = image1 != null ? image3.Url : string.Empty,

                ImageLargeUrl1 = imageLarge1 != null ? imageLarge1.Url : string.Empty,
                ImageLargeUrl2 = imageLarge2 != null ? imageLarge2.Url : string.Empty,
                ImageLargeUrl3 = imageLarge1 != null ? imageLarge3.Url : string.Empty,
            };
            return viewModel;
        }
    }
}