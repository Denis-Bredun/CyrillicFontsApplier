using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CyrillicFontsApplier.Client.Constants;
using System.Collections.ObjectModel;

namespace CyrillicFontsApplier.Client.ViewModels
{
    public partial class SelectFontViewModel : ObservableObject
    {
        [ObservableProperty]
        private FontInfoViewModel _selectedFont;

        public string ExampleText { get; } = UIConstants.TextForExampleOfUsedFont;
        public ObservableCollection<FontInfoViewModel> Fonts { get; } = FontList.Fonts;
              
        public SelectFontViewModel()
        {
            SelectedFont = Fonts.FirstOrDefault();
        }

        [RelayCommand]
        public void ChangeFavouriteState(FontInfoViewModel font)
        {
            font.IsFavorite = !font.IsFavorite;
        }
    }
}
