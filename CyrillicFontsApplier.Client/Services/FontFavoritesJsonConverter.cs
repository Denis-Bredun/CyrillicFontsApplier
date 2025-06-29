using CyrillicFontsApplier.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Client.Services
{
    public class FontFavoritesJsonConverter : IDictionaryToJsonConverter<string, bool>
    {
        private static JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            WriteIndented = true
        };

        public string Serialize(Dictionary<string, bool> fontsFavoriteStates)
            => JsonSerializer.Serialize(fontsFavoriteStates, _serializerOptions);

        public Dictionary<string, bool> Deserialize(string json)
            => JsonSerializer.Deserialize<Dictionary<string, bool>>(json);
    }
}
