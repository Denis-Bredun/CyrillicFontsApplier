using CyrillicFontsApplier.Client.Enums;
using CyrillicFontsApplier.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Client.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IPageFactory _factory;

        public NavigationService(IPageFactory factory)
        {
            _factory = factory;
        }

        public async Task NavigateTo(PageType type)
        {
            var pageRoute = _factory.GetPageRoute(type);
            await Shell.Current.GoToAsync(pageRoute);
        }
    }
}
