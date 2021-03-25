using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Core.Models
{
	[Table( "AppComments" )]
	public class Comment : BaseEntity<long>
	{
		public string Content { get; set; }
		public long UserId { get; set; }
		public User User { get; set; }
		public long ParentCommentId { get; set; }
		public long PostId { get; set; }
	}
}
