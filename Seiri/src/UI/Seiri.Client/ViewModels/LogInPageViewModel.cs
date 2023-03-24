namespace Seiri.Client.ViewModels;

using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Seiri.Application.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Commands;
using Prism.Navigation;

public partial class LogInPageViewModel : BindableBase
{
	#region Fields

	private readonly IRegionManager regionManager;
	private readonly IMediator mediator;
	private readonly IValidator<LogInPageViewModel> validator;
	private readonly INavigationService navigationService;

	public ICommand SubmitCommand { get; private set; }

	//private string email;
	//private string password;
	private string emailTextIsValid;
	private string passwordTextIsValid;

	#endregion

	#region Contructor

	public LogInPageViewModel(IRegionManager regionManager, IMediator mediator, IValidator<LogInPageViewModel> validator, INavigationService navigationService) 
	{
		this.regionManager = regionManager;
		this.mediator = mediator;
		this.validator = validator;
		this.navigationService = navigationService;

		SubmitCommand = new DelegateCommand(Submit);
	}

	

	#endregion

	#region Properties

	public bool CanSend
	{
		get
		{
			var validationResult = validator.Validate(this);
			return validationResult.IsValid;
		}

	}

	public string EmailValidationText
	{
		get => emailTextIsValid;
		set
		{
			SetProperty(ref emailTextIsValid, value);
			RaisePropertyChanged(nameof(CanSend));
		}
	}

	public string PasswordValidationText
	{
		get => passwordTextIsValid;
		set
		{
			SetProperty(ref passwordTextIsValid, value);
			RaisePropertyChanged(nameof(CanSend));
		}
	}

	//public string Email
	//{
	//	get => email;
	//	set
	//	{
	//		SetProperty(ref email, value);
	//		RaisePropertyChanged(nameof(CanSend));


	//	}
	//}

	//public string Password
	//{
	//	get => password;
	//	set
	//	{
	//		SetProperty(ref password, value);
	//		RaisePropertyChanged(nameof(CanSend));


	//	}
	//}

	//public string EmailValidationText { get; set; }
	//public string PasswordValidationText { get; set; }

	public string Email { get; set; }

	public string Password { get; set; }

	public async void Submit()
	{
		var valResult = validator.Validate(this);

		if (!valResult.IsValid)
		{
			var errorEmail = valResult.Errors.FirstOrDefault(e => e.PropertyName == nameof(Email));
			var errorPassword = valResult.Errors.FirstOrDefault(e => e.PropertyName == nameof(Password));

			if (errorEmail != null)
			{
				EmailValidationText = errorEmail.ErrorMessage;
			}
			else
			{
				EmailValidationText = string.Empty;
			}

			if (errorPassword != null)
			{
				PasswordValidationText = errorPassword.ErrorMessage;
			}
			else
			{
				PasswordValidationText = string.Empty;
			}

			return;
		}

		EmailValidationText = string.Empty;
		PasswordValidationText = string.Empty;

		var command = new AuthenticateUserCommand
		{
			Username = Email,
			Password = Password,
		};

		var response = await mediator.Send(command);

		if (response?.Response != null)
		{
			navigationService.NavigateAsync("/ShellPage")
				.OnNavigationError(ex => Console.WriteLine(ex));
		}
		else
		{
		}
	}

	#endregion


}