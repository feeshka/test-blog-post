using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public class PostDto
	{
		public string Name { get; set; }
		public string CreationDate { get; set; }
		public double Rating { get; set; }
		public string OwnerUserName { get; set; }
		public string OwnerUserId { get; set; }
		public string Content { get; set; }
	}
}
