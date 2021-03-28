using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public class BlogCreateDto
	{
		public string BlogComment { get; set; }
		public string BlogName { get; set; }
		public string UserId { get; set; }
		public long Id { get; set; }
	}
}
