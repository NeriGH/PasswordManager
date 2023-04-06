using Microsoft.Extensions.DependencyInjection;
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
