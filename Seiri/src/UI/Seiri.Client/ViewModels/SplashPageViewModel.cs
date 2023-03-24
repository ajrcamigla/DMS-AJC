namespace Seiri.Client.ViewModels
{
	using System;
	using System.Threading.Tasks;
	using Prism.AppModel;
	using Prism.Navigation;

	internal class SplashPageViewModel : IPageLifecycleAware
	{
		private INavigationService _navigationService { get; }

		public SplashPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public async void OnAppearing()
		{
			await Task.Delay(TimeSpan.FromSeconds(5));
			_navigationService.CreateBuilder()
				.UseAbsoluteNavigation()
				.AddSegment<LogInPageViewModel>()
				.Navigate();
		}

		public void OnDisappearing()
		{

		}
	}
}
