namespace Seiri.Domain.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public  class AuthenticationResponse
	{
		public string? UserId { get; set; }

		public string? AccessToken { get; set; }
	}
}
