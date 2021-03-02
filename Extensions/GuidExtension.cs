using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity;

namespace SitefinityWebApp.Extensions
{
    public static class GuidExtension
    {
        public static string GetImageUrl(this Guid guid)
        {
            if(guid != Guid.Empty)
            {
                try
                {
                    return App.WorkWith().Image(guid).Get().Url;
                }
                catch
                {

                }
            }
            return string.Empty;
        }
        public static Telerik.Sitefinity.Libraries.Model.Image GetImage(this Guid guid)
        {
            if (guid != Guid.Empty)
            {
                try
                {
                    return App.WorkWith().Image(guid).Get();
                }
                catch
                {

                }
            }
            return new Telerik.Sitefinity.Libraries.Model.Image();
        }
    }
}