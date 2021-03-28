using Blog.Core.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Core
{
	public interface IBaseDalFacade<TCreateDto, TDto, TInListDto, TKey, TSearchInput>
	{
		Task<TKey> InsertAndGetIdAsync( TCreateDto entity );
		Task<bool> UpdateAsync( TCreateDto entity );
		Task<bool> DeleteAsync( TKey id );
		Task<IEnumerable<TInListDto>> GetAllAsync( TSearchInput filter );
		Task<TDto> GetByIdAsync( TKey id );
	}
}
