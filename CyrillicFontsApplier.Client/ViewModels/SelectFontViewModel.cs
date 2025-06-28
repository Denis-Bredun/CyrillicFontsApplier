using CommunityToolkit.Mvvm.ComponentModel;
using CyrillicFontsApplier.Client.Constants;
using System.Collections.ObjectModel;

namespace CyrillicFontsApplier.Client.ViewModels
{
    public partial class SelectFontViewModel : ObservableObject
    {
        [ObservableProperty]
        private string exampleText = UIConstants.TextForExampleOfUsedFont;

        [ObservableProperty]
        private ObservableCollection<FontDisplayInfo> fonts;

        [ObservableProperty]
        private FontDisplayInfo selectedFont;

        public SelectFontViewModel()
        {
            Fonts = new ObservableCollection<FontDisplayInfo>(
                FontList.Fonts.Values
                    .Select(v => new FontDisplayInfo
                    {
                        Value = v,
                        Name = v.Replace("Regular", "")
                    })
                    .OrderBy(f => f.Name)
            );

            SelectedFont = Fonts.FirstOrDefault();
        }
    }

    public class FontDisplayInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
