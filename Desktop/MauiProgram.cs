using Base.IRepositories;
using Base.IServices;
using Base.Repositories;
using Base.Services;
using Base.Singletons;
using Microsoft.Extensions.Logging;

namespace Desktop
{
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

            builder.Services.AddMauiBlazorWebView();
            //Singgleton Declaration
            builder.Services.AddSingleton<Names>();
            //Scoped Declaration
            builder.Services.AddScoped<IDatabase, Database>();
            builder.Services.AddScoped<IService, Service>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
