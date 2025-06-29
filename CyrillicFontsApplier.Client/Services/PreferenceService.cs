using CyrillicFontsApplier.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Client.Services
{
    public class PreferenceService : IPreferenceService<string, string>
    {
        public string GetPreference(string key, string? defaultValue = default)
            => Preferences.Get(key, defaultValue);

        public void SetPreference(string key, string value)
            => Preferences.Set(key, value);
    }
}
