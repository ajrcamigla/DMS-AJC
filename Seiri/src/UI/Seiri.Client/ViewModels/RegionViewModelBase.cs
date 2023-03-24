namespace Seiri.Client.ViewModels
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Prism.AppModel;
	using Prism.Common;
	using Prism.Mvvm;
	using Prism.Navigation;
	using Prism.Regions.Navigation;

	public class RegionViewModelBase : BindableBase, IRegionAware, IPageLifecycleAware
	{
		public RegionViewModelBase(INavigationService navigationService, IPageAccessor pageAccessor)
		{
			_navigationService = navigationService;
			_pageAccessor = pageAccessor;
		}

		public string PageName => _pageAccessor.Page?.GetType()?.Name;

		protected INavigationService _navigationService { get; }

		protected IRegionNavigationService _regionNavigation { get; private set; }

		protected string Name => GetType().Name.Replace("ViewModel", string.Empty);

		private IPageAccessor _pageAccessor { get; }

		public bool IsNavigationTarget(INavigationContext navigationContext) =>
			navigationContext.NavigatedName() == Name;

		public void OnAppearing()
		{
			RaisePropertyChanged(nameof(PageName));
		}

		public void OnDisappearing()
		{

		}

		public void OnNavigatedFrom(INavigationContext navigationContext)
		{

		}

		public void OnNavigatedTo(INavigationContext navigationContext)
		{

		}
	}
}
