using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
	public interface IUserAuthDalFacade
	{
		Task<bool> RegisterAsync (UserSignUpDto userDto);
		Task LogIn (UserSignInDto userDto);
	}
}
