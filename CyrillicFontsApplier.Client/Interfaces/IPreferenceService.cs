using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Client.Interfaces
{
    public interface IPreferenceService<TKey, TValue>
    {
        TValue GetPreference(TKey key, TValue? defaultValue = default);
        void SetPreference(TKey key, TValue value);
    }
}
