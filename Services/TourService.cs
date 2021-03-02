using SitefinityWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitefinityWebApp.Extensions;
using SitefinityWebApp.Mvc.Models.PopularTours;
using Newtonsoft.Json;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Utilities.TypeConverters;
using SitefinityWebApp.Core;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.RelatedData;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.DynamicModules.Model;

namespace SitefinityWebApp.Services
{
    public class TourService : ITourService
    {
        public List<PopularToursItemModel> GetItemsBySelectedIds(string ids)
        {
            List<PopularToursItemModel> popularToursItemModel = new List<PopularToursItemModel>();
            if (!string.IsNullOrEmpty(ids))
            {
                var data = JsonConvert.DeserializeObject<List<Guid>>(ids);
                if (data.Any())
                {
                    var manager = DynamicModuleManager.GetManager();
                    Type Tour = TypeResolutionService.ResolveType(DynamicContentConstants.DynamicContent.Types.Tour);

                    TaxonomyManager taxaManager = TaxonomyManager.GetManager();
                    var adventuresTaxa = taxaManager.GetTaxa<FlatTaxon>().Where(t => t.Taxonomy.Name == DynamicContentConstants.DynamicContent.Tours.Adventures).ToList();
                    var difficultiesTaxa = taxaManager.GetTaxa<FlatTaxon>().Where(t => t.Taxonomy.Name == DynamicContentConstants.DynamicContent.Tours.Difficulties).ToList();
                    //get the selected items
                    var items = manager.GetDataItems(Tour).Where(item => item.Status == ContentLifecycleStatus.Live && item.Visible).Where(item => data.Contains(item.Id)).ToList();

                    //order items as selected
                    var orderedItems = items.OrderBy(item => data.IndexOf(item.Id)).ToList();

                    foreach(var item in orderedItems)
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
                            Accomodation = accomodationChoiceFields.Any() ? string.Join(",",accomodationChoiceFields):string.Empty,
                            ImageUrl = image!=null ?image.MediaUrl:string.Empty
                        };
                        popularToursItemModel.Add(model);
                    }
                }
            }
            return popularToursItemModel;
        }
    }
}