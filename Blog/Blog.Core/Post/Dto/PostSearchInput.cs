using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public class PostSearchInput
	{
		public DateTime? CreationFrom { get; set; }
		public DateTime? CreationTo { get; set; }
		public int? RatingFrom { get; set; }
		public int? RatingTo { get; set; }
		public string OwnerName { get; set; }
		public string PostName { get; set; }
	}
}
