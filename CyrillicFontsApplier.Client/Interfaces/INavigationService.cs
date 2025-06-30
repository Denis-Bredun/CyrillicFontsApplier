using CyrillicFontsApplier.Client.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Client.Interfaces
{
    public interface INavigationService
    {
        Task NavigateTo(PageType type);
    }
}
