using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public class BlogCreateDto
	{
		public string BlogComment { get; set; }
		public double Rating { get; set; }
		public string BlogName { get; set; }
		public string OwnerUserId { get; set; }
	}
}
