using Blog.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Blog.Core.User;
using Microsoft.Extensions.Configuration;
using Blog.Core.Models;
using Microsoft.Extensions.Options;

namespace Blog.Application.Services.Infrastructure
{
	public class UserAuthService: IUserAuthService
	{
		public UserAuthService (IUserAuthDalFacade userAuthDalFacade, IOptions<ApplicationSettings> appsettings)
		{
			_userAuthDalFacade = userAuthDalFacade;
			_appsettings = appsettings.Value;
		}

		private readonly IUserAuthDalFacade _userAuthDalFacade;
		private readonly ApplicationSettings _appsettings;
		public async Task<LoginResultDto> LogInAsync (UserSignInDto userDto )
		{
			try
			{

				userDto.PasswordHash = GetPasswordHash( userDto.Password );

				var user = await _userAuthDalFacade.FindByEmailAsync( userDto.Email );
				if ( user == null )
					return new LoginResultDto { Success = false, Message = $"Пользователь {userDto.Email} не найден" };
				var passwordValid = userDto.PasswordHash == user.PasswordHash;
				if ( !passwordValid )
					return new LoginResultDto { Success = false, Message = $"Неправильный пароль" };

				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity( new Claim[]
					{
						new Claim( "UserId", user.Id ),
						new Claim( "ExpDate", DateTime.UtcNow.AddDays(7).ToString() )
					} ),
					Expires = DateTime.UtcNow.AddDays( 7 ),
					SigningCredentials = new SigningCredentials( new SymmetricSecurityKey( Encoding.UTF8.GetBytes( _appsettings.SecretKey ) ), SecurityAlgorithms.HmacSha256Signature )
				};

				var tokenHandler = new JwtSecurityTokenHandler();
				var secureToken = tokenHandler.CreateToken( tokenDescriptor );
				var token = tokenHandler.WriteToken( secureToken );

				return new LoginResultDto { Success = true, UserId = user.Id, Token = token };
			}
			catch ( Exception ex )
			{
				throw new Exception( ex.Message );
			}
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
