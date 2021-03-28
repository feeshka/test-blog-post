using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Core.Models
{
	[Table( "AppPostsRatings" )]
	public class PostsRating : BaseEntity<long>
	{
		public int UsersCount { get; set; }
		public int Stars { get; set; }
	}
}
