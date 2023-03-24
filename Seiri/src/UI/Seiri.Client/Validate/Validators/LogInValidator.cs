namespace Seiri.Client.Validate.Validators
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using FluentValidation;
	using Seiri.Client.ViewModels;

	public class LogInValidator : AbstractValidator<LogInPageViewModel>
	{
		public LogInValidator()
		{
			RuleFor(x => x.Email).NotEmpty().WithMessage("Must not Empty")
				.EmailAddress().WithMessage("Invalid Email");

			RuleFor(x => x.Password).NotEmpty().WithMessage("Must not Empty");

		}

	}
}
