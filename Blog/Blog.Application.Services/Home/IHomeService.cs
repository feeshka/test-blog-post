using Blog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
	public interface IHomeService
	{
		Task<IEnumerable<TopBlogInListDto>> GetTopBlogsAsync( int count );
		Task<IEnumerable<TopPostInListDto>> GetTopPostsAsync( int count );
	}
}
