using CyrillicFontsApplier.Client.Views;

namespace CyrillicFontsApplier.Client
{
    public partial class App : Application
    {
        public App(AppShell appShell)
        {
            InitializeComponent();

            MainPage = appShell;
        }
    }
}
