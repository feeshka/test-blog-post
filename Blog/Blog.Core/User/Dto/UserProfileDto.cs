using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public class UserProfileDto
	{
		public string Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string FullName { get; set; }
	}
}
