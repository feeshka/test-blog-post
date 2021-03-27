using Blog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.Infrastructure
{
	public class UserService : IUserService
	{
		public UserService( IUserDalFacade userDalFacade )
		{
			_userDalFacade = userDalFacade;
		}

		private readonly IUserDalFacade _userDalFacade;
		public async Task<UserProfileDto> GetProfileByUserIdAsync( string id )
		{
			return await _userDalFacade.GetProfileByUserIdAsync( id );
		}

		public async Task<IEnumerable<BlogInListDto>> GetCurrentUserBlogsAsync( string id )
		{
			return await _userDalFacade.GetCurrentUserBlogsAsync( id );
		}
	}
}
