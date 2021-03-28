using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
	public interface IBaseAppService<TCreateDto, TDto, TInListDto, TKey, TSearchInput>
	{
		public Task<IEnumerable<TInListDto>> GetAllAsync (TSearchInput input);
		public Task<TDto> GetByIdAsync (TKey blogId);
		public Task<TKey> CreateNewAsync ( TCreateDto newBlog );
		Task<bool> UpdateAsync( TCreateDto entity );
		public Task<bool> DeleteByIdAsync (TKey id);
	}
}
