using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Core.Models
{
	[Table( "AppPostTags" )]
	public class PostTag : BaseEntity<int>
	{
		public string Name { get; set; }
		public int CreatorUserId { get; set; }
	}
}
