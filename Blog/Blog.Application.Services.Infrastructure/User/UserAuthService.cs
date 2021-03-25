using Blog.Core;
using Microsoft.AspNetCore.Identity;
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

		public async Task<IdentityResult> RegisterAsync (UserSignUpDto userDto)
		{
			try
			{
				userDto.PasswordHash = GetPasswordHash(userDto.Password);

				return await _userAuthDalFacade.RegisterAsync(userDto);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		private string GetPasswordHash (string password)
		{
			byte[] data = Encoding.ASCII.GetBytes(password);
			data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
			return Encoding.ASCII.GetString(data);
		}
	}
}
