using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
	public interface IHomeDalFacade
	{
		Task<IEnumerable<TopBlogInListDto>> GetTopBlogsAsync( int count );
		Task<IEnumerable<TopPostInListDto>> GetTopPostsAsync( int count );
	}
}
