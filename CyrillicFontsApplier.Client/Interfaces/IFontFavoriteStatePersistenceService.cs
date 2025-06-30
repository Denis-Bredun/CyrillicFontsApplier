using CyrillicFontsApplier.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Client.Interfaces
{
    public interface IFontFavoriteStatePersistenceService
    {
        void Load(IEnumerable<FontInfoViewModel> fonts);
        void Save(IEnumerable<FontInfoViewModel> fonts);
    }
}
