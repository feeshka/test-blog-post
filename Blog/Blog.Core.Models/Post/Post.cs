using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Core.Models
{
	[Table( "AppPosts" )]
	public class Post : BaseEntity<long>
	{
		public string Name { get; set; }
		public long BlogId { get; set; }
		public User CreatorUser { get; set; }
		public string CreatorUserId { get; set; }
		public ICollection<PostTag> Tags { get; set; }
		public long RatingId { get; set; }
		public ICollection<Comment> Comments { get; set; }
	}
}
