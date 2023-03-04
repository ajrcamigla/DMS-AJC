using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seiri.Domain.Interfaces;
using Seiri.Domain.Models;

namespace Seiri.Infrastructure.Services.Mocks
{
	public class MockAuthenticationService : IAuthenticationService
	{
		private List<User> users = new List<User>()
		{
			new User {Id = "123", Email="JohnDoe@gmail.com", Password = "John1234" },
			new User {Id = "456", Email="SusanBaker@gmail.com", Password = "Susan1234" }
		};
		public Task<AuthenticationResponse> SignIn(string username, string password)
		{
			var user = users.FirstOrDefault(x => x.Email.Equals(username, StringComparison.OrdinalIgnoreCase) && x.Password == password);

			if (user != null)
			{
				return Task.FromResult(new AuthenticationResponse
				{
					UserId = user.Id,
					AccessToken = "accesstoken",
				});

			}
			return Task.FromResult(default(AuthenticationResponse)); 

		}
	}
}
