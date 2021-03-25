using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Core.Models
{
	public class BaseEntity<TPrimaryKey>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public TPrimaryKey Id { get; set; }
		public DateTime CreationDate { get; set; }
		public bool Deleted { get; set; }
	}
}
