using SitefinityWebApp.Mvc.Models.Hero;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "Hero",Title ="Hero",SectionName = "Hero")]
    public class HeroController : Controller
    {
        private HeroEditorModel _model;
        private string _template = "Default";
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public HeroEditorModel Model
        {
            get
            {
                if (this._model == null)
                    this._model = new HeroEditorModel();
                return this._model;
            }
            
        }
        public ActionResult Index()
        {
            var viewModel = this._model.GetViewModel();
            return View("Hero" + this._template, viewModel);
        }
    }
}