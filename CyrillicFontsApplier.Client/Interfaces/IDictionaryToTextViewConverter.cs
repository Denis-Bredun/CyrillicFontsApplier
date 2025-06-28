using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Client.Interfaces
{
    public interface IDictionaryToJsonConverter<TKey, TValue> where TKey : notnull
    {
        string Serialize(Dictionary<TKey, TValue> dictionary);
        Dictionary<TKey, TValue> Deserialize(string json);
    }
}
