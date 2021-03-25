using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
	public interface IUserDalFacade : IBaseDalFacade<UserDto, UserInListDto, long, UserSearchInput>
	{

	}
}
