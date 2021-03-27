using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.User
{
	public class LoginResultDto
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public string Token { get; set; }
		public string UserId { get; set; }
	}
}
