using Blog.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Services
{
	public interface IBlogService : IBaseAppService<BlogCreateDto, BlogDto, BlogInListDto, long, BlogSearchInput>
	{

	}
}
