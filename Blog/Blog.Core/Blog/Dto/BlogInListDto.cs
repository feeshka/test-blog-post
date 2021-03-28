using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public class BlogInListDto
	{
		public long Id { get; set; }
		public string BlogName { get; set; }
		public int BlogRating { get; set; }
		public string BlogShortComment { get; set; }
		public DateTime BlogCreationDate { get; set; }

		public int PostsCount { get; set; }
	}
}
