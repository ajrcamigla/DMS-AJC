namespace Seiri.Client
{
	using System.Reflection.Metadata;
	using Prism.Ioc;
	using Prism.Modularity;
	using Prism.Regions;
	using Seiri.Client.ViewModels;
	using Seiri.Client.Views;

	public class SeiriModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();

			regionManager.RegisterViewWithRegion("FullDetailRegion", "FullDetailView");
			regionManager.RegisterViewWithRegion("MenuRegion", "MenuView");
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry
				.RegisterForNavigation<ShellPage>()
				.RegisterForRegionNavigation<MenuView, MenuViewModel>()
				.RegisterForRegionNavigation<FullDetailView, FullDetailViewModel>()
				.RegisterForRegionNavigation<DocumentView, DocumentViewModel>();
		}
	}
}
