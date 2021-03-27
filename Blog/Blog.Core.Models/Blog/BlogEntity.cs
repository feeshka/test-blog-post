using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Models
{
	[Table( "AppBlogs" )]
	public class BlogEntity : BaseEntity<long>
	{
		public string Name { get; set; }
		public string UserId { get; set; }
		public User User { get; set; }
		public string Comment { get; set; }
		public ICollection<BlogTag> Tags { get; set; }
	}
}
