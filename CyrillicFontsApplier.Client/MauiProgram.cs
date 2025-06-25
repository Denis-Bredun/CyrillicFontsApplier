using Microsoft.Extensions.Logging;

namespace CyrillicFontsApplier.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();
            ConfigureFonts(builder);

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void ConfigureFonts(MauiAppBuilder builder)
        {
            builder.ConfigureFonts(fonts =>
            {
                foreach (var font in Constants.FontList.Fonts)
                {
                    fonts.AddFont(font.Key, font.Value);
                }
            });
        }
    }
}
