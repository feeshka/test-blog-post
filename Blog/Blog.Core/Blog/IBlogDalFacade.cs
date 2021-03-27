using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public interface IBlogDalFacade: IBaseDalFacade<BlogCreateDto, BlogDto, BlogInListDto, long, BlogSearchInput>
	{
	}
}
