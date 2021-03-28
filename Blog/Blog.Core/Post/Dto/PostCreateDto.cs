using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public class PostCreateDto
	{
		public string PostComment { get; set; }
		public string PostName { get; set; }
		public string OwnerUserId { get; set; }
		public long Id { get; set; }
		public string BlogId { get; set; }
	}
}
