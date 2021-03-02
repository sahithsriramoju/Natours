using SitefinityWebApp.Core;
using SitefinityWebApp.Extensions;
using SitefinityWebApp.Mvc.Models.PopularTours;
using SitefinityWebApp.Mvc.Models.Tours;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.RelatedData;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "Tours" , Title = "Tours", SectionName = "Tours")]
    public class ToursController : Controller
    {
        private string _template = "Default";
        public ToursViewModel  model = new ToursViewModel();
        public ActionResult Index()
        {
            List<PopularToursItemModel> popularToursItemModel = new List<PopularToursItemModel>();
            var manager = DynamicModuleManager.GetManager();
            Type Tour = TypeResolutionService.ResolveType(DynamicContentConstants.DynamicContent.Types.Tour);

            TaxonomyManager taxaManager = TaxonomyManager.GetManager();
            var adventuresTaxa = taxaManager.GetTaxa<FlatTaxon>().Where(t => t.Taxonomy.Name == DynamicContentConstants.DynamicContent.Tours.Adventures).ToList();
            var difficultiesTaxa = taxaManager.GetTaxa<FlatTaxon>().Where(t => t.Taxonomy.Name == DynamicContentConstants.DynamicContent.Tours.Difficulties).ToList();
            //get the selected items
            var items = manager.GetDataItems(Tour).Where(item => item.Status == ContentLifecycleStatus.Live && item.Visible).ToList();

            

            foreach (var item in items)
            {
                var image = item.GetRelatedItems(DynamicContentConstants.DynamicContent.Tours.ThumbnailImage).FirstOrDefault() as Image;
                var adventureTaxaTitles = item.GetAssociatedTagNamesForContentItem(DynamicContentConstants.DynamicContent.Tours.Adventures, adventuresTaxa);
                var difficultyTaxaTitles = item.GetAssociatedTagNamesForContentItem(DynamicContentConstants.DynamicContent.Tours.Difficulties, difficultiesTaxa);
                var accomodationChoiceFields = item.GetValue<IEnumerable<ChoiceOption>>(DynamicContentConstants.DynamicContent.Tours.Accomodation).ToList();
                var model = new PopularToursItemModel
                {
                    Title = item.GetString(DynamicContentConstants.DynamicContent.Tours.Title),
                    Description = item.GetString(DynamicContentConstants.DynamicContent.Tours.Description),
                    NoOfDays = Convert.ToString(item.GetValue(DynamicContentConstants.DynamicContent.Tours.NoOfDays)),
                    SizeOfTour = Convert.ToString(item.GetValue(DynamicContentConstants.DynamicContent.Tours.SizeOfTour)),
                    NoOfTourGuides = Convert.ToString(item.GetValue(DynamicContentConstants.DynamicContent.Tours.NoOfTourGuides)),
                    Price = Convert.ToString(item.GetValue(DynamicContentConstants.DynamicContent.Tours.Price)),
                    AdventureTags = adventureTaxaTitles.Any() ? string.Join(",", adventureTaxaTitles) : string.Empty,
                    DifficultyTags = difficultyTaxaTitles.Any() ? string.Join(",", difficultyTaxaTitles) : string.Empty,
                    Accomodation = accomodationChoiceFields.Any() ? string.Join(",", accomodationChoiceFields) : string.Empty,
                    ImageUrl = image != null ? image.MediaUrl : string.Empty
                };
                popularToursItemModel.Add(model);
            }
            model.toursItemModel = popularToursItemModel;
            return View("Tours" + this._template, model);
       
}

    }
}