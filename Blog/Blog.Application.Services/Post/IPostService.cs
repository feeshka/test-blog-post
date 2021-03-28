using Blog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
	public interface IPostService : IBaseAppService<PostCreateDto, PostDto, PostInListDto, long, PostSearchInput>
	{
		Task<IEnumerable<BlogSelectItemDto>> GetBlogsForSelectForUserAsync( string userId );

	}
}
