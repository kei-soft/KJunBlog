﻿using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;

namespace Maui.ToolKitMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // FileSaver 주입
            builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
            builder.Services.AddTransient<MainPage>();

            Routing.RegisterRoute("drawpage", typeof(DrawPage));

            return builder.Build();
        }
    }
}