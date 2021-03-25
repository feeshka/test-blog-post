using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
	public interface IBaseAppService<TDto, TInListDto, TKey, TSearchInput>
	{
		public Task<IEnumerable<TInListDto>> GetAllAsync (TSearchInput input);
		public Task<TDto> GetByIdAsync (TKey blogId);
		public Task<TKey> CreateNewAsync (TDto newBlog);
		public Task<bool> DeleteByIdAsync (TKey id);
	}
}
