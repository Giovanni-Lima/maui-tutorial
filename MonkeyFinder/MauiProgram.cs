using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using MonkeyFinder.Services;
using MonkeyFinder.Services.Interfaces;
using MonkeyFinder.View;

namespace MonkeyFinder;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

        builder.ConfigureMauiHandlers(handlers =>
        {
#if ANDROID
            EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
                handler.PlatformView.BackgroundTintList =
                    Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
            });
#endif
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

		builder.Services.AddTransient<MonkeyDetailsViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<ITokenService, TokenService>();
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
		builder.Services.AddSingleton<IMap>(Map.Default);


        return builder.Build();
	}
}
