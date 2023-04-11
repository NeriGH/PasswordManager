using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.LifecycleEvents;
using PasswordManager.Services;
using PasswordManager.ViewModels;
using PasswordManager.Views;

namespace PasswordManager;

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

        builder.ConfigureLifecycleEvents(lifecycle =>
        {
#if WINDOWS
                    lifecycle
            .AddWindows(windows =>
                windows.OnPlatformMessage((app, args) => {
                    if (PasswordManager.Platforms.Windows.WindowExtensions.Hwnd == IntPtr.Zero)
                    {
                        PasswordManager.Platforms.Windows.WindowExtensions.Hwnd = args.Hwnd;
                        PasswordManager.Platforms.Windows.WindowExtensions.SetIcon("Platforms/Windows/trayicon.ico");
                    }
                     app.ExtendsContentIntoTitleBar = false;
                        }));
#endif
        });

#if WINDOWS
            builder.Services.AddSingleton<ITrayService, PasswordManager.Platforms.Windows.TrayService>();
#endif



        //Service
        builder.Services.AddSingleton<IPasswordService,PasswordService>();

        //View Registration
        builder.Services.AddSingleton<PasswordListPage>();
        builder.Services.AddTransient<AddUpdatePasswordDetail>();

        //View Models
        builder.Services.AddSingleton<PasswordListPageViewModel>();
        builder.Services.AddTransient<AddUpdatePasswordDetailViewModel>();

        return builder.Build();
	}
}
