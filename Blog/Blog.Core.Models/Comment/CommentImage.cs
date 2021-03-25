using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Core.Models
{
	[Table( "AppCommentsImages" )]
	public class CommentImage
	{
		public long PostId { get; set; }
		public byte[] Content { get; set; }
	}
}
