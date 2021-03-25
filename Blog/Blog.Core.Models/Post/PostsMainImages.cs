using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Core.Models
{
	[Table( "AppPostsMainImages" )]
	public class PostsMainImages : BaseEntity<long>
	{
		public long PostId { get; set; }
		public byte[] Content { get; set; }
	}
}
