using Blog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.Infrastructure
{
	public class PostService : IPostService
	{
		public PostService( IPostDalFacade postDalFacade )
		{
			_postDalFacade = postDalFacade;
		}

		private readonly IPostDalFacade _postDalFacade;

		public async Task<IEnumerable<PostInListDto>> GetAllAsync( PostSearchInput input )
		{
			try
			{
				return await _postDalFacade.GetAllAsync( input );
			}
			catch ( Exception ex )
			{
				throw new Exception( ex.Message );
			}
		}

		public async Task<PostDto> GetByIdAsync( long postId )
		{
			try
			{
				return await _postDalFacade.GetByIdAsync( postId );
			}
			catch ( Exception ex )
			{
				throw new Exception( ex.Message );
			}
		}

		public async Task<long> CreateNewAsync( PostCreateDto newPost )
		{
			try
			{
				return await _postDalFacade.InsertAndGetIdAsync( newPost );
			}
			catch ( Exception ex )
			{
				throw new Exception( ex.Message );
			}
		}

		public async Task<bool> DeleteByIdAsync( long id )
		{
			try
			{
				return await _postDalFacade.DeleteAsync( id );
			}
			catch ( Exception ex )
			{
				throw new Exception( ex.Message );
			}
		}

		public async Task<IEnumerable<BlogSelectItemDto>> GetBlogsForSelectForUserAsync( string userId )
		{
			try
			{
				return await _postDalFacade.GetBlogsForSelectForUserAsync( userId );
			}
			catch ( Exception ex )
			{
				throw new Exception( ex.Message );
			}
		}

		public async Task<bool> UpdateAsync( PostCreateDto entity )
		{
			try
			{
				return await _postDalFacade.UpdateAsync( entity );
			}
			catch ( Exception ex )
			{
				throw new Exception( ex.Message );
			}
		}
	}
}
