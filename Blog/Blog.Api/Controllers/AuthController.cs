using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Services;
using Blog.Core;
using Blog.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		public AuthController (IUserAuthService userAuthService)
		{
			_userAuthService = userAuthService;
		}
		private readonly IUserAuthService _userAuthService;

		[HttpPost]
		[Route("Registration")]
		public async Task<IActionResult> RegisterUser ([FromBody]UserSignUpDto userDto)
		{
			var registerResult = await _userAuthService.RegisterAsync(userDto);
			if (registerResult)
				return Ok();
			else
				return BadRequest();
		}
	}
}
