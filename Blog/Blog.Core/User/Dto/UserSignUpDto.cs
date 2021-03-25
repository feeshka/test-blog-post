using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public class UserSignUpDto
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string PasswordHash { get; set; }

	}
}
