using CyrillicFontsApplier.Client.ViewModels;

namespace CyrillicFontsApplier.Client.Views;

public partial class SelectFontView : ContentPage
{
    public SelectFontView()
    {
        InitializeComponent();

        BindingContext = new SelectFontViewModel();
    }
}