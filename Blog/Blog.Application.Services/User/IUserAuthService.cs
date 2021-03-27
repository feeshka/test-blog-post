using Blog.Core;
using Blog.Core.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
	public interface IUserAuthService
	{
		Task<IdentityResult> RegisterAsync (UserSignUpDto userDto);
		Task<LoginResultDto> LogInAsync (UserSignInDto userDto);

	}
}
