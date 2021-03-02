using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.OpenAccess;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Taxonomies.Model;

namespace SitefinityWebApp.Extensions
{
    public static class DynamicContentExtension
    {
        public static List<string> GetAssociatedTagNamesForContentItem(this DynamicContent item,string fieldName, List<FlatTaxon> listOfTaxa)
        {
            var taxa = new List<string>();
            var contentItemIds = item.GetValue<TrackedList<Guid>>(fieldName);

            foreach(var tagId in contentItemIds)
            {
                var itemTaxa = listOfTaxa.FirstOrDefault(t => t.Id == tagId);
                if(itemTaxa != null)
                {
                    taxa.Add(itemTaxa.Title);
                }
            }
            return taxa;
        }
    }
}