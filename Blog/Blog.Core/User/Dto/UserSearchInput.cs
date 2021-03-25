using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public class UserSearchInput
	{
		public string UserName { get; set; }
		public string FullName { get; set; }
		public DateTime RegDateFrom { get; set; }
		public DateTime RegDateTo { get; set; }
	}
}
