﻿using MediatR;
using Seiri.Domain.Interfaces;
using Seiri.Domain.Models;

namespace Seiri.Application.Commands
{
    public class AuthenticateUserCommand :IRequest<AuthenticateUserCommandResponse>
    {
		public string Username { get; set; }

		public string Password { get; set; }
    }

	public class AuthenticateUserCommandResponse  
	{
		public AuthenticationResponse Response { get; set; }
	}

	public class CreateUserDeviceCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserCommandResponse>
	{
		private readonly IAuthenticationService authenticationService;

		public CreateUserDeviceCommandHandler(IAuthenticationService authenticationService)
		{
			this.authenticationService = authenticationService;
		}

		public async Task<AuthenticateUserCommandResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
		{
			var response = await authenticationService.SignIn(request.Username, request.Password);

			return new AuthenticateUserCommandResponse { Response = response };
		}
	}

}