using CyrillicFontsApplier.Client.Constants;
using CyrillicFontsApplier.Client.HelperClasses;
using CyrillicFontsApplier.Client.Interfaces;
using CyrillicFontsApplier.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Client.Services
{
    public class FontFavoriteStatePersistenceService(
        IPreferenceService<string, string> preferences,
        IDictionaryToJsonConverter<string, bool> converter)
    {
        private const string PreferencesKey = "FontFavourite";
        private const string DefaultValue = "{}";

        public void Save(IEnumerable<FontInfoViewModel> fonts)
        {
            var map = FontInfoMapper.MapFontsToFavoritesDictionary(fonts);
            var json = converter.Serialize(map);
            preferences.SetPreference(PreferencesKey, json);
        }

        public void Load(IEnumerable<FontInfoViewModel> fonts)
        {
            var json = preferences.GetPreference(PreferencesKey, DefaultValue);

            if (IsJsonMissingOrEmpty(json))
                throw new InvalidOperationException(Exceptions.FontFavoritesNotFound);

            var map = converter.Deserialize(json);
            FontInfoMapper.ApplyFavoritesDictionaryToFonts(fonts, map);
        }

        private static bool IsJsonMissingOrEmpty(string json)
            => string.IsNullOrWhiteSpace(json) || json.Trim() == DefaultValue;
    }
}
