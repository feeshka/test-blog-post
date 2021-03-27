using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Blog.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Blog.Core.Infrastructure
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext (DbContextOptions options)
			: base(options)
		{

		}

		#region DbSet

		public DbSet<BlogEntity> Blogs { get; set; }
		public DbSet<Blog.Core.Models.User> AppUsers { get; set; }

		#endregion

		protected override void OnModelCreating (ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<BlogEntity>(b =>
			{
			});
		}
	}
}
