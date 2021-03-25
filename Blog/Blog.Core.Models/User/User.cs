using Microsoft.AspNetCore.Identity;
using System;

namespace Blog.Core.Models
{
	public class User: IdentityUser
	{
		public DateTime CreationDate { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Guid Guid { get; set; }
		public bool Deleted { get; set; }
	}
}
