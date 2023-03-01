namespace Seiri.Client
{
	using Seiri.Client.ViewModels;
	using Seiri.Client.Views;

	internal class PrismStartup
	{
			public static void Configure(PrismAppBuilder builder)
			{
				builder.RegisterTypes(RegisterTypes)
					.OnAppStart("NavigationPage/LogInPage");
			}

			private static void RegisterTypes(IContainerRegistry containerRegistry)
			{
				containerRegistry.RegisterForNavigation<LogInPage, LogInViewModel>()
					   .RegisterInstance(SemanticScreenReader.Default);
			}
		
	}
}
