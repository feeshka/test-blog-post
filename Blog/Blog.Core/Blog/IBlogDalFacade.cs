using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public interface IBlogDalFacade: IBaseDalFacade<BlogDto, BlogInListDto, long, BlogSearchInput>
	{
	}
}
