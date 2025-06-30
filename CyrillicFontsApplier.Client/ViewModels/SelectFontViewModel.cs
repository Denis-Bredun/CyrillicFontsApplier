using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CyrillicFontsApplier.Client.Constants;
using CyrillicFontsApplier.Client.Enums;
using CyrillicFontsApplier.Client.Events;
using CyrillicFontsApplier.Client.Interfaces;
using System.Collections.ObjectModel;

namespace CyrillicFontsApplier.Client.ViewModels
{
    public partial class SelectFontViewModel : ObservableObject
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private FontInfoViewModel _selectedFont;

        public string ExampleText { get; } = UIConstants.TextForExampleOfUsedFont;
        public ObservableCollection<FontInfoViewModel> Fonts { get; } = FontList.Fonts;
              
        public SelectFontViewModel(
            IEventAggregator eventAggregator,
            INavigationService navigationService)
        {
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;

            SelectedFont = Fonts.FirstOrDefault();
        }

        [RelayCommand]
        public void ChangeFavouriteState(FontInfoViewModel font)
        {
            font.IsFavorite = !font.IsFavorite;
        }

        [RelayCommand]
        public void ApplyFontEverywhere()
        {
            if(SelectedFont != null) 
                _eventAggregator.GetEvent<FontSelectedEvent>().Publish(SelectedFont);
        }

        [RelayCommand]
        public async Task GoBackToMainPage()
        {
            await _navigationService.NavigateTo(PageType.MainPage);
        }
    }
}
