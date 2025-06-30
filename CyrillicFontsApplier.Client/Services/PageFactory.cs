using CyrillicFontsApplier.Client.Enums;
using CyrillicFontsApplier.Client.Interfaces;
using CyrillicFontsApplier.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Client.Services
{
    public class PageFactory : IPageFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PageFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public string GetPageRoute(PageType type)
        {
            return type switch
            {
                PageType.MainPage => "//MainPage",
                PageType.SelectFontPage => "//SelectFontPage",
                PageType.ContactsPage => "//ContactsPage"
            };
        }
    }
}
