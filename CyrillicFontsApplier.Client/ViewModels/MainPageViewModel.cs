using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CyrillicFontsApplier.Client.Constants;
using CyrillicFontsApplier.Client.Events;
using CyrillicFontsApplier.Client.Interfaces;
using CyrillicFontsApplier.Client.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Client.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private FontInfoViewModel _selectedFont;

        public MainPageViewModel(
            IEventAggregator eventAggregator,
            INavigationService navigationService)
        {
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;

            SelectedFont = FontList.Fonts.FirstOrDefault();

            _eventAggregator.GetEvent<FontSelectedEvent>().Subscribe(OnFontSelected);
        }

        [RelayCommand]
        public async Task GoToSelectFontPage()
        {
            await _navigationService.NavigateTo(PageType.SelectFontPage);
        }

        private void OnFontSelected(FontInfoViewModel font)
        {
            SelectedFont = font;
        }
    }
}
