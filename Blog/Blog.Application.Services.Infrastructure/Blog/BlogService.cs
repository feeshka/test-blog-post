using Blog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.Infrastructure
{
	public class BlogService : IBlogService
	{
		public BlogService (IBlogDalFacade blogDalFacade)
		{
			_blogDalFacade = blogDalFacade;
		}

		private readonly IBlogDalFacade _blogDalFacade;

		public async Task<IEnumerable<BlogInListDto>> GetAllAsync (BlogSearchInput input)
		{
			try
			{
				return await _blogDalFacade.GetAllAsync(input);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<BlogDto> GetByIdAsync (long blogId)
		{
			try
			{
				return await _blogDalFacade.GetByIdAsync(blogId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<long> CreateNewAsync ( BlogCreateDto newBlog )
		{
			try
			{
				return await _blogDalFacade.InsertAndGetIdAsync(newBlog);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<bool> DeleteByIdAsync (long id)
		{
			try
			{
				return await _blogDalFacade.DeleteAsync(id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
