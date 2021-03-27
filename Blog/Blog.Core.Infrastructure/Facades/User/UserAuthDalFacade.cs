using AutoMapper;
using Blog.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Infrastructure
{
	public class UserAuthDalFacade: IUserAuthDalFacade
	{
		public UserAuthDalFacade (UserManager<Blog.Core.Models.User> userManager, SignInManager<Blog.Core.Models.User> signInManager, IMapper mapper)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_mapper = mapper;
		}
		private readonly UserManager<Blog.Core.Models.User> _userManager;
		private readonly SignInManager<Blog.Core.Models.User> _signInManager;
		protected readonly IMapper _mapper;

		public async Task<IdentityResult> RegisterAsync (UserSignUpDto userDto)
		{
			try
			{
				var user = _mapper.Map<Blog.Core.Models.User>(userDto);
				return await _userManager.CreateAsync(user);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<Blog.Core.Models.User> FindByEmailAsync( string email )
		{
			return await _userManager.FindByEmailAsync( email );
		}
	}
}
