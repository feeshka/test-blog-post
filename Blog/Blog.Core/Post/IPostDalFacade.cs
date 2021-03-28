using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
	public interface IPostDalFacade: IBaseDalFacade<PostCreateDto, PostDto, PostInListDto, long, PostSearchInput>
	{
		Task<IEnumerable<BlogSelectItemDto>> GetBlogsForSelectForUserAsync( string userId );
	}
}
