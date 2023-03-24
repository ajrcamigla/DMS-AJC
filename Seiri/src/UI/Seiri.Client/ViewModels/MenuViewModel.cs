namespace Seiri.Client.ViewModels
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Prism.Commands;
	using Prism.Common;
	using Prism.Navigation;
	using Prism.Regions;

	public class MenuViewModel : RegionViewModelBase 
	{
		private readonly IRegionManager regionManager;
		public MenuViewModel(INavigationService navigationService, IRegionManager regionManager, IPageAccessor pageAccessor) : base(navigationService, pageAccessor)
		{
			this.regionManager = regionManager;
			NavigateToHomePageCommand = new DelegateCommand(NavigateToHome);

			NavigateToDocumentPageCommand = new DelegateCommand(NavigateToDocument);
		}

		private void NavigateToDocument()
		{
			regionManager.RequestNavigate("FullDetailRegion", "DocumentView");
		}

		private void NavigateToHome()
		{
			regionManager.RequestNavigate("FullDetailRegion", "FullDetailView");
		}

		public ICommand NavigateToHomePageCommand { get; private set; }

		public ICommand NavigateToDocumentPageCommand { get; private set; }
	}
}
