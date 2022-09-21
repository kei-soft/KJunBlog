using SimpleToolkit.Core;

namespace Maui.SimpleToolKitTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSimpleToolkit()
                //.DisplayContentBehindBars()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            //#if ANDROID

            //            builder.SetDefaultStatusBarAppearance(color: Color.FromRgb(26, 129, 197), lightElements: false);
            //            builder.SetDefaultNavigationBarAppearance(color: Colors.White, lightElements: false);

            //#endif

            return builder.Build();
        }
    }
}