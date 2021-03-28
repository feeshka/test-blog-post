using Blog.Application.Services;
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
	public class HomeController : Controller
	{
		public HomeController( IHomeService homeService )
		{
			_homeService = homeService;
		}

		private readonly IHomeService _homeService;

		[HttpGet]
		[Route( "top-blogs" )]
		public async Task<IActionResult> GetTopBlogs( [FromQuery] int count )
		{
			var result = await _homeService.GetTopBlogsAsync( count );
			return Json( result );
		}

		[HttpGet]
		[Route( "top-posts" )]
		public async Task<IActionResult> GetTopPosts( [FromQuery] int count )
		{
			var result = await _homeService.GetTopPostsAsync( count );
			return Json( result );
		}
	}
}
