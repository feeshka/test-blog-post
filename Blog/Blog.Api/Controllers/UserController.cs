using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
	[Route( "api/[controller]" )]
	[ApiController]
	public class UserController : Controller
	{
		public UserController( IUserService userService)
		{
			_userService = userService;
		}

		private readonly IUserService _userService;
		[HttpGet]
		[Authorize]
		[Route("Dashboard")]
		public async Task<IActionResult> GetUserPersonalProfile([FromQuery]string userId )
		{
			var result = await _userService.GetProfileByUserIdAsync( userId );
			return Json( result );
		}

		[HttpGet]
		[Authorize]
		[Route( "Dashboard/current-user-blogs" )]
		public async Task<IActionResult> GetCurrentUserBlogs([FromQuery] string userId)
		{
			var result = await _userService.GetCurrentUserBlogsAsync( userId );
			return Json( result );
		}

		[HttpGet]
		[Authorize]
		[Route( "Dashboard/current-user-posts" )]
		public async Task<IActionResult> GetCurrentUserPosts( [FromQuery] string userId )
		{
			var result = await _userService.GetCurrentUserPostsAsync( userId );
			return Json( result );
		}
	}
}
