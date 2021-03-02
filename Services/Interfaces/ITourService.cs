using SitefinityWebApp.Mvc.Models.PopularTours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitefinityWebApp.Services.Interfaces
{
    interface ITourService
    {
        List<PopularToursItemModel> GetItemsBySelectedIds(string ids);
    }
}
