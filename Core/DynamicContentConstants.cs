using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Core
{
    public static class DynamicContentConstants
    {
        public class DynamicContent
        {
            public class Types
            {
                public const string Tour = "Telerik.Sitefinity.DynamicTypes.Model.Tours.Tour";
            }
            public class Tours
            {
                public const string Title = "Title";
                public const string Description = "Description";
                public const string Accomodation = "Accomdation";
                public const string NoOfDays = "NoOfDays";
                public const string SizeOfTour = "SizeOfTour";
                public const string NoOfTourGuides = "NoOfTourGuides";
                public const string Price = "Price";
                public const string Adventures = "adventures";
                public const string Difficulties = "difficulties";
                public const string ThumbnailImage = "ThumbnailImage";
            }
        }
    }
}