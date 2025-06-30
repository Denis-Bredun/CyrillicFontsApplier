using CyrillicFontsApplier.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Client.Events
{
    public class FontSelectedEvent : PubSubEvent<FontInfoViewModel> { }
}
