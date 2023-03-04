namespace Seiri.Client.ViewModels;

using System.Security.Cryptography;
using System.Windows.Input;
using MediatR;
using Seiri.Application.Commands;

public partial class LogInViewModel : BindableBase
{
	private readonly IRegionManager regionManager;
	private readonly IMediator mediator;

	public ICommand SubmitCommand { get; private set; }

	public LogInViewModel(IRegionManager regionManager, IMediator mediator)
	{
		this.regionManager = regionManager;
		this.mediator = mediator;

		SubmitCommand = new DelegateCommand(Submit);
	}

	public string? Email	{get;set;}

	public string? Password { get; set; }

	public async void Submit()
	{
		var command = new AuthenticateUserCommand
		{
			Username = Email,
			Password = Password,
		};

		var response = await mediator.Send(command);

		if (response?.Response != null)
		{
		}
		else
		{
		}
	}


}