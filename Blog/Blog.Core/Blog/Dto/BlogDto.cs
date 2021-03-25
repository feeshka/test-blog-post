using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public class BlogDto
	{
		public string Name { get; set; }
		public DateTime CreationDate { get; set; }
		public double Rating { get; set; }
		public string OwnerUserName { get; set; }
		public long OwnerUserId { get; set; }
	}
}
