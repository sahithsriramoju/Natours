using SitefinityWebApp.Mvc.Models.ImageGallery;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "ImageGallery", Title = "Image Gallery", SectionName = "Gallery")]
    public class ImageGalleryController : Controller
    {
        private ImageGalleryEditorModel _model;
        private string _template = "Default";
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ImageGalleryEditorModel Model
        {
            get
            {
                if (this._model == null)
                    this._model = new ImageGalleryEditorModel();
                return this._model;
            }
        }
        public ActionResult Index()
        {
            var viewModel = this._model.GetViewModel();
            return View("ImageGallery" + this._template, viewModel);
        }
    }
}