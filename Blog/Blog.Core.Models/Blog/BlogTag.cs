using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Core.Models
{
	[Table( "AppBlogTags" )]
	public class BlogTag : BaseEntity<int>
	{
		public string Name { get; set; }
		public string CreatorUserId { get; set; }
	}
}
