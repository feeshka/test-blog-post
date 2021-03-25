using Blog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.Infrastructure
{
	public class UserAuthService: IUserAuthService
	{
		public UserAuthService (IUserAuthDalFacade userAuthDalFacade)
		{
			_userAuthDalFacade = userAuthDalFacade;
		}

		private readonly IUserAuthDalFacade _userAuthDalFacade;
		public Task LogIn (UserSignInDto entity)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> RegisterAsync (UserSignUpDto userDto)
		{
			try
			{
				return await _userAuthDalFacade.RegisterAsync(userDto);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
