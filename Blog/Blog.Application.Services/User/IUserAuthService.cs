using Blog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
	public interface IUserAuthService
	{
		Task<bool> RegisterAsync (UserSignUpDto userDto);
		Task LogIn (UserSignInDto userDto);

	}
}
