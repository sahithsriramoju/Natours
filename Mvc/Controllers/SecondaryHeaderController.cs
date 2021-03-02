using SitefinityWebApp.Mvc.Models.SecondaryHeader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "SecondaryHeader", Title = "Secondary Header", SectionName = "Header")]
    public class SecondaryHeaderController : Controller
    {
        private SecondaryHeaderEditorModel _model;
        private string _template = "Default";
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public SecondaryHeaderEditorModel Model
        {
            get
            {
                if(this._model == null)
                {
                    this._model = new SecondaryHeaderEditorModel();
                }
                return this._model;
            }
        }

        public ActionResult Index()
        {
            var viewModel = this._model.GetViewModel();
            return View("SecondaryHeader" + this._template, viewModel);
        }

    }
}