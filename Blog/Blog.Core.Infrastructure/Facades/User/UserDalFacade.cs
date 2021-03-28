using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Infrastructure
{
	public class UserDalFacade : IUserDalFacade
	{
		public UserDalFacade( ApplicationDbContext context, IMapper mapper )
		{
			_context = context;
			_mapper = mapper;
		}

		protected readonly ApplicationDbContext _context;
		protected readonly IMapper _mapper;

		public Task<bool> DeleteAsync( string id )
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<UserInListDto>> GetAllAsync( UserSearchInput filter )
		{
			throw new NotImplementedException();
		}

		public Task<UserDto> GetByIdAsync( string id )
		{
			throw new NotImplementedException();
		}

		public async Task<UserProfileDto> GetProfileByUserIdAsync( string id )
		{
			var profile = await _context.Users.Where( x => x.Id == id ).FirstOrDefaultAsync();
			if ( profile == null )
				throw new Exception( $"User #{id} not found!" );

				return _mapper.Map<UserProfileDto>( profile );
		}

		public Task<string> InsertAndGetIdAsync( UserDto entity )
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateAsync( UserDto entity )
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<BlogInListDto>> GetCurrentUserBlogsAsync( string id )
		{
			return await _context.Blogs
				.Include(x=> x.Posts)
				.Where(x=> x.UserId == id)
				.Select( x => _mapper.Map<BlogInListDto>( x ) )
				.ToListAsync();
		}
	}
}
