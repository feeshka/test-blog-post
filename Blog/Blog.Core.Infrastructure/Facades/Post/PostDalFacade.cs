using AutoMapper;
using Blog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Infrastructure
{
	public class PostDalFacade : IPostDalFacade
	{
		public PostDalFacade( ApplicationDbContext context, IMapper mapper )
		{
			_context = context;
			_mapper = mapper;
		}

		protected readonly ApplicationDbContext _context;
		protected readonly IMapper _mapper;

		public async Task<IEnumerable<BlogSelectItemDto>> GetBlogsForSelectForUserAsync( string userId )
		{
			return await _context.Blogs
				.Where( x => x.UserId == userId )
				.Select( x => _mapper.Map<BlogSelectItemDto>( x ) )
				.ToListAsync();
		}

		public async Task<bool> DeleteAsync( long id )
		{
			try
			{
				var entity = await _context.Posts.Where( x => x.Id == id ).FirstOrDefaultAsync();

				if ( entity == null )
					throw new Exception( $"Post #{id} not found!" );

				entity.Deleted = true;
				await _context.SaveChangesAsync();
				return true;
			}
			catch ( Exception ex )
			{
				//_logger.log(DateTime.UtcNow, ex.Message)
				throw new Exception( ex.Message );
			}
		}

		//TODO: Take all filters
		public async Task<IEnumerable<PostInListDto>> GetAllAsync( PostSearchInput filter )
		{
			try
			{
				return await _context.Posts
							.Include( x => x.CreatorUser )
							.Where( x => filter.CreationFrom.HasValue && x.CreationDate >= filter.CreationFrom )
							.Where( x => filter.CreationTo.HasValue && x.CreationDate <= filter.CreationTo )
							.Where( x => !String.IsNullOrEmpty( filter.PostName ) && x.Name.Contains( filter.PostName ) )
							.Select( x => _mapper.Map<PostInListDto>( x ) )
							.ToListAsync();
			}
			catch ( Exception ex )
			{
				throw new Exception( ex.Message );
			}
		}

		public async Task<PostDto> GetByIdAsync( long id )
		{
			try
			{
				var entity = await _context.Posts.Where( x => x.Id == id ).FirstOrDefaultAsync();

				if ( entity == null )
					throw new Exception( $"Post #{id} not found!" );

				return _mapper.Map<PostDto>( entity );
			}
			catch ( Exception ex )
			{
				throw new Exception( ex.Message );
			}

		}

		public async Task<long> InsertAndGetIdAsync( PostCreateDto entity )
		{
			try
			{
				var newEntity = _mapper.Map<Post>( entity );
				_context.Posts.Add( newEntity );
				await _context.SaveChangesAsync();

				return newEntity.Id;
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
				var storage = await _context.Posts.Where( x => x.Id == entity.Id ).FirstOrDefaultAsync();
				if ( storage == null )
					throw new Exception( "Not found" );

				storage = _mapper.Map<Post>( storage );
				await _context.SaveChangesAsync();
				return true;
			}
			catch ( Exception ex )
			{
				throw new Exception( ex.Message );
			}
		}
	}
}
