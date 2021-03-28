using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
	public interface IUserDalFacade : IBaseDalFacade<UserDto, UserDto, UserInListDto, string, UserSearchInput>
	{
		Task<UserProfileDto> GetProfileByUserIdAsync(string id);
		Task<IEnumerable<BlogInListDto>> GetCurrentUserBlogsAsync( string id );
		Task<IEnumerable<PostInListDto>> GetCurrentUserPostsAsync( string id );
	}
}
