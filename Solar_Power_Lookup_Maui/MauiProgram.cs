﻿namespace Solar_Power_Lookup_Maui;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        //Register pages here:
        builder.Services.AddSingleton<SolarServices>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<SolarDataMain>();


        //Add pages and classes associated with additional pages here
        builder.Services.AddTransient<SolarDetailsViewModel>();
        builder.Services.AddTransient<SolarDetailsPage>();

        return builder.Build();
    }
}
