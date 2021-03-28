using Blog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
	public interface IBlogService : IBaseAppService<BlogCreateDto, BlogDto, BlogInListDto, long, BlogSearchInput>
	{
		Task<IEnumerable<PostInListDto>> GetPostsForBlog( long postId );
	}
}
