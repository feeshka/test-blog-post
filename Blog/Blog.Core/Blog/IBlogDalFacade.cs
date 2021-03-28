using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
	public interface IBlogDalFacade: IBaseDalFacade<BlogCreateDto, BlogDto, BlogInListDto, long, BlogSearchInput>
	{
		Task<IEnumerable<PostInListDto>> GetPostsForBlog( long postId );
	}
}
