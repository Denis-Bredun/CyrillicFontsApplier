using CommunityToolkit.Maui;
using CyrillicFontsApplier.Client.Interfaces;
using CyrillicFontsApplier.Client.Services;
using CyrillicFontsApplier.Client.ViewModels;
using CyrillicFontsApplier.Client.Views;
using Microsoft.Extensions.Logging;

namespace CyrillicFontsApplier.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            ConfigureAppEssentials(builder);

            builder.Services
                .AddAppServices()
                .AddViewModels()
                .AddPagesWithoutViewModels();

            ConfigurePlatformSpecifics();

            return builder.Build();
        }

        private static void ConfigureAppEssentials(MauiAppBuilder builder)
        {
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit();

            ConfigureFonts(builder);

#if DEBUG
            builder.Logging.AddDebug();
#endif
        }

        private static void ConfigureFonts(MauiAppBuilder builder)
        {
            builder.ConfigureFonts(fonts =>
            {
                foreach (var font in Constants.FontList.Fonts)
                {
                    fonts.AddFont(font.Filename, font.Alias);
                }
            });
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddSingleton<IEventAggregator, EventAggregator>();

            services.AddScoped<IPreferenceService<string, string>, PreferenceService>();
            services.AddScoped<IDictionaryToJsonConverter<string, bool>, FontFavoritesJsonConverter>();
            services.AddScoped<IFontFavoriteStatePersistenceService, FontFavoriteStatePersistenceService>();
            services.AddScoped<IPageFactory, PageFactory>();
            services.AddScoped<INavigationService, NavigationService>();

            return services;
        }

        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddViewModel<SelectFontViewModel, SelectFontView>();
            services.AddViewModel<MainPageViewModel, MainPageView>();

            return services;
        }

        public static IServiceCollection AddPagesWithoutViewModels(this IServiceCollection services)
        {
            services.AddScoped<ContactsView>();
            services.AddScoped<AppShell>();

            return services;
        }

        public static void AddViewModel<TViewModel, TView>(this IServiceCollection services)
            where TView : ContentPage, new()
            where TViewModel : class
        {
            services.AddSingleton<TViewModel>();
            services.AddScoped<TView>(s => new TView { BindingContext = s.GetRequiredService<TViewModel>() });
        }

        private static void ConfigurePlatformSpecifics()
        {
#if ANDROID
            Microsoft.Maui.Handlers.ScrollViewHandler.Mapper.ModifyMapping("HorizontalScrollBarVisibility", (handler, view, args) =>
            {
                handler.PlatformView.HorizontalScrollBarEnabled = true;
                handler.PlatformView.ScrollBarFadeDuration = 0;
            });

            Microsoft.Maui.Handlers.ScrollViewHandler.Mapper.ModifyMapping("VerticalScrollBarVisibility", (handler, view, args) =>
            {
                handler.PlatformView.VerticalScrollBarEnabled = true;
                handler.PlatformView.ScrollBarFadeDuration = 0;
            });
#endif
        }        
    }
}
