using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CyrillicFontsApplier.Client.Constants;
using CyrillicFontsApplier.Client.Enums;
using CyrillicFontsApplier.Client.Events;
using CyrillicFontsApplier.Client.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CyrillicFontsApplier.Client.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private FontInfoViewModel _selectedFont;

        public ObservableCollection<FontInfoViewModel> FavouriteFonts { get; } = new();

        public MainPageViewModel(
            IEventAggregator eventAggregator,
            INavigationService navigationService)
        {
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;

            SelectedFont = FontList.Fonts.FirstOrDefault();

            foreach (var font in FontList.Fonts)
                font.PropertyChanged += Font_PropertyChanged;

            UpdateFavouriteFonts();

            _eventAggregator.GetEvent<FontSelectedEvent>().Subscribe(OnFontSelected);
        }

        private void UpdateFavouriteFonts()
        {
            FavouriteFonts.Clear();
            foreach (var font in FontList.Fonts.Where(f => f.IsFavorite))
                FavouriteFonts.Add(font);
        }

        private void Font_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FontInfoViewModel.IsFavorite))
            {
                var font = (FontInfoViewModel)sender;

                if (font.IsFavorite)
                {
                    if (!FavouriteFonts.Contains(font))
                        FavouriteFonts.Add(font);
                }
                else
                {
                    if (FavouriteFonts.Contains(font))
                        FavouriteFonts.Remove(font);
                }
            }
        }

        [RelayCommand]
        public async Task GoToSelectFontPage()
        {
            await _navigationService.NavigateTo(PageType.SelectFontPage);
        }

        [RelayCommand]
        public void ChangeFavouriteState(FontInfoViewModel font)
        {
            font.IsFavorite = !font.IsFavorite;
        }

        private void OnFontSelected(FontInfoViewModel font)
        {
            SelectedFont = font;
        }        
    }
}
