using Microsoft.Extensions.Logging;

namespace ConsoleApp17;

using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
            builder.UseBurkusMvvm(burkusMvvm =>
            {
                burkusMvvm.OnStart(async (navigationService, serviceProvider) =>
                {

                        // we are logged in to the app
                        await navigationService.Navigate("/MainPage");
                });
            })
            .RegisterViews()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }


    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<MainPage>();

        return mauiAppBuilder;
    }
}