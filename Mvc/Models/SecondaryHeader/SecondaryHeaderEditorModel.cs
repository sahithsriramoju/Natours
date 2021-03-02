using SitefinityWebApp.Mvc.Models.SecondaryHeader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models.SecondaryHeader
{
    public class SecondaryHeaderEditorModel
    {
        public string Title { get; set; }

        public SecondaryHeaderViewModel GetViewModel()
        {
            var viewModel = new SecondaryHeaderViewModel()
            {
                Title = this.Title,
            };
            return viewModel;
        }
    }
}