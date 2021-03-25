using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Core.Models
{
	[Table( "AppPostsImages" )]
	public class PostImage
	{
		public long PostId { get; set; }
		public byte[] Content { get; set; }
	}
}
