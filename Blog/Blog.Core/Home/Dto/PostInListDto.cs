using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public class TopPostInListDto
	{
		public long Id { get; set; }
		public string PostName { get; set; }
		public string AuthorName { get; set; }
		public int PostRating { get; set; }
		public DateTime PostCreationDate { get; set; }
	}
}
