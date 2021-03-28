using AutoMapper;
using Blog.Core.Models;
using Blog.Core.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Infrastructure
{
	public class BlogDalFacade : IBlogDalFacade
	{
		public BlogDalFacade (ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		protected readonly ApplicationDbContext _context;
		protected readonly IMapper _mapper;

		//TODO: Mark as deleted all children
		public async Task<bool> DeleteAsync (long id)
		{
			try
			{
				var entity = await _context.Blogs.Where(x => x.Id == id).FirstOrDefaultAsync();

				if (entity == null)
					throw new Exception($"Blog #{id} not found!");

				entity.Deleted = true;
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				//throw new Exception($"Blog #{id} not found!");
				throw new Exception(ex.Message);
			}
		}

		//TODO: Take all filters
		public async Task<IEnumerable<BlogInListDto>> GetAllAsync (BlogSearchInput filter)
		{
			try
			{
				return await _context.Blogs
							.Include(x=> x.User)
							.Where(x => filter.CreationFrom.HasValue && x.CreationDate >= filter.CreationFrom)
							.Where(x => filter.CreationTo.HasValue && x.CreationDate <= filter.CreationTo)
							.Where(x => !String.IsNullOrEmpty(filter.BlogName) && x.Name.Contains(filter.BlogName))
							//.Where(x => !String.IsNullOrEmpty(filter.OwnerName) && x.User.Name.Contains(filter.OwnerName))
							.Select(x => _mapper.Map<BlogInListDto>(x))
							.ToListAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<BlogDto> GetByIdAsync (long id)
		{
			try
			{
				var entity = await _context.Blogs.Where(x => x.Id == id).FirstOrDefaultAsync();

				if (entity == null)
					throw new Exception($"Blog #{id} not found!");

				return _mapper.Map<BlogDto>(entity);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}

		public async Task<long> InsertAndGetIdAsync ( BlogCreateDto entity )
		{
			try
			{
				var newEntity = _mapper.Map<BlogEntity>(entity);
				_context.Blogs.Add(newEntity);
				await _context.SaveChangesAsync();

				return newEntity.Id;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<bool> UpdateAsync ( BlogCreateDto entity )
		{
			try
			{
				var storage = await _context.Blogs.Where( x => x.Id == entity.Id ).FirstOrDefaultAsync();
				if ( storage == null )
					throw new Exception( "Not found" );

				storage = _mapper.Map<BlogEntity>( storage );
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
