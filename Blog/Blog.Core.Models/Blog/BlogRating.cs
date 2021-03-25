using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Core.Models
{
	[Table( "AppBlogsRatings" )]
	public class BlogRating : BaseEntity<long>
	{
		public int UsersCount { get; set; }
		public double Stars { get; set; }
	}
}
