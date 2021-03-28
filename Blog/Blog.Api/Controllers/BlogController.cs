using Blog.Application.Services;
using Blog.Core;
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
	public class BlogController : Controller
	{
		public BlogController( IBlogService blogService)
		{
			_blogService = blogService;
		}

		private readonly IBlogService _blogService;

		[HttpPost]
		[Route("new-blog")]
		[Authorize]
		public async Task<IActionResult> CreateNewBlog( [FromBody]BlogCreateDto newBlog)
		{
			var result = await _blogService.CreateNewAsync( newBlog );
			return Json( result );
		}
	}
}
