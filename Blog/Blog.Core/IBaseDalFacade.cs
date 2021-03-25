using Blog.Core.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Core
{
	public interface IBaseDalFacade<TDto, TInListDto, TKey, TSearchInput>
	{
		Task<TKey> InsertAndGetIdAsync( TDto entity );
		Task<bool> UpdateAsync( TDto entity );
		Task<bool> DeleteAsync( TKey id );
		Task<IEnumerable<TInListDto>> GetAllAsync( TSearchInput filter );
		Task<TDto> GetByIdAsync( TKey id );
	}
}
