using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Common;
using Prism.Navigation;

namespace Seiri.Client.ViewModels
{
	public class DocumentViewModel : RegionViewModelBase
	{
		public DocumentViewModel(INavigationService navigationService, IPageAccessor pageAccessor) : base(navigationService, pageAccessor)
		{
		}
	}
}
