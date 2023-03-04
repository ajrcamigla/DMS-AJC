namespace Seiri.Client;

using Infrastructure.Data.Repositories.Models;
using CommunityToolkit.Maui;
using Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using ViewModels;
using Views;
using Microsoft.Extensions.Logging;
using Material.Components.Maui.Extensions;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Microsoft.Maui.LifecycleEvents;
using Prism.Ioc;


public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.UseMauiApp<App>().UsePrism(PrismStartup.Configure);
		builder.UseMauiCommunityToolkit(options =>
		{
			options.SetShouldSuppressExceptionsInAnimations(true);
			options.SetShouldSuppressExceptionsInBehaviors(true);
			options.SetShouldSuppressExceptionsInConverters(true);
		});

		builder
			.UseMaterialComponents(new List<string>
			{
                //generally, we needs add 6 types of font families
                "Montserrat-Regular.ttf",
				"Montserrat-Italic.ttf",
				"Montserrat-Medium.ttf",
				"Montserrat-MediumItalic.ttf",
				"Montserrat-Bold.ttf",
				"Montserrat-BoldItalic.ttf",
			});

		builder.UseSkiaSharp();
		builder.Services.AddMediatR(x =>
		{
			x.RegisterServicesFromAssemblies(typeof(Seiri.Application.Commands.AuthenticateUserCommand).Assembly);
		});
		builder.Services.AddSingleton<LogInViewModel>();
		builder.Services.AddSingleton<LogInPage>();



		var app = builder.Build();
		return app;
	}

	private static string GetDatabaseConnectionString(string filename)
	{
		return $"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename)}.db";
	}

	
}