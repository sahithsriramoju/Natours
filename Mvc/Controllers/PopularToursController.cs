using SitefinityWebApp.Mvc.Models.PopularTours;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.ContentLocations;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Utilities.TypeConverters;
using SitefinityWebApp.Core;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.DynamicModules;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name ="PopularTours",Title ="Popular Tours",SectionName ="Tours")]
    public class PopularToursController : Controller, IContentLocatableView
    {
        private PopularToursEditorModel _model;
        private string _template = "Default";
        string itemType = DynamicContentConstants.DynamicContent.Types.Tour;
        public string ItemType
        {
            get { return this.itemType; }
            set { this.itemType = value; }
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public PopularToursEditorModel Model
        {
            get
            {
                if (this._model == null)
                    this._model = new PopularToursEditorModel();
                return this._model;
            }
        }
        public ActionResult Index()
        {
            var viewModel = Model.GetViewModel();
            return View("PopularTours" + this._template, viewModel);
        }
        public bool? DisableCanonicalUrlMetaTag { get; set; }
        public IEnumerable<IContentLocationInfo> GetLocations()
        {
            var locations = new List<IContentLocationInfo>();

            //add module location specfics
            var localTourModule = new ContentLocationInfo();

            localTourModule.ContentType = TypeResolutionService.ResolveType(DynamicContentConstants.DynamicContent.Types.Tour);
            var manager = DynamicModuleManager.GetManager();
            localTourModule.ProviderName = manager.Provider.Name;
            locations.Add(localTourModule);
            return locations;
        }
    }
}