namespace Seiri.Client;

using CommunityToolkit.Maui;
using FluentValidation;
using Material.Components.Maui.Extensions;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation;
using Seiri.Client.Validate.Validators;
using Seiri.Domain.Interfaces;
using Seiri.Infrastructure.Services.Mocks;
using SkiaSharp.Views.Maui.Controls.Hosting;
using ViewModels;
using Views;


public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UsePrism(prism =>
			{
				prism.ConfigureModuleCatalog(moduleCatalog =>
				{
					moduleCatalog.AddModule<SeiriModule>();
				});
				prism.RegisterTypes(containerRegistry =>
				{
					containerRegistry.RegisterSingleton<IAuthenticationService, MockAuthenticationService>();
					containerRegistry.RegisterForNavigation<SplashPage, SplashPageViewModel>();
					containerRegistry.RegisterForNavigation<LogInPage, LogInPageViewModel>();
					containerRegistry.RegisterSingleton<IValidator<LogInPageViewModel>, LogInValidator>();
				})
				.OnAppStart(navigationService => navigationService.CreateBuilder()
				.AddSegment<SplashPageViewModel>()
				.NavigateAsync(HandleNavigationError));
			});
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
				"password.ttf",
			});

		builder.UseSkiaSharp();
		builder.Services.AddMediatR(x =>
		{
			x.RegisterServicesFromAssemblies(typeof(Seiri.Application.Commands.AuthenticateUserCommand).Assembly);
		});


		var app = builder.Build();
		return app;
	}

	

	private static string GetDatabaseConnectionString(string filename)
	{
		return $"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename)}.db";
	}


	private static void HandleNavigationError(Exception ex)
	{
		Console.WriteLine(ex);
		System.Diagnostics.Debugger.Break();
	}

}