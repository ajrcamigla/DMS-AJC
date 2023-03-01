namespace Seiri.Client.ViewModels;

using System.Security.Cryptography;
using System.Windows.Input;

public partial class LogInViewModel : BindableBase
{
	private readonly IRegionManager regionManager;

	public ICommand SubmitCommand { get; private set; }

	public LogInViewModel(IRegionManager regionManager)
	{
		this.regionManager = regionManager;

		SubmitCommand = new DelegateCommand(Submit);
	}

	public string? Email	{get;set;}

	public string? Password { get; set; }

	public void Submit()
	{

	}


}