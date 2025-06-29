using CyrillicFontsApplier.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Client.HelperClasses
{
    public static class FontInfoMapper
    {
        public static Dictionary<string, bool> MapFontsToFavoritesDictionary(
            IEnumerable<FontInfoViewModel> fonts)
            => fonts.ToDictionary(f => f.Alias, f => f.IsFavorite);

        public static void ApplyFavoritesDictionaryToFonts(
            IEnumerable<FontInfoViewModel> fonts,
            Dictionary<string, bool> favorites)
        {
            foreach (var font in fonts)
            {
                if(favorites.TryGetValue(font.Alias, out var isFavourite))
                    font.IsFavorite = isFavourite;
            }
        }
    }
}
