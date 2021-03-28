using Blog.Application.Services;
using Blog.Core;
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
	public class PostController : Controller
	{
		public PostController( IPostService postService )
		{
			_postService = postService;
		}

		private readonly IPostService _postService;

		[HttpGet]
		[Route( "get-blog-select-options" )]
		public async Task<IActionResult> GetBlogsForSelectForUser( [FromQuery] string userId )
		{
			var result = await _postService.GetBlogsForSelectForUserAsync( userId );
			return Json( result );
		}

		[HttpPost]
		[Route( "list" )]
		public async Task<IActionResult> GetAll( [FromBody] PostSearchInput input)
		{
			var result = await _postService.GetAllAsync( input );
			return Json( result );
		}

		[HttpGet]
		[Route( "get-post" )]
		public async Task<IActionResult> GetPost( [FromQuery] long id )
		{
			var result = await _postService.GetByIdAsync( id );
			return Json( result );
		}

		[HttpPost]
		[Route( "create" )]
		public async Task<IActionResult> CreateNewPost( [FromBody] PostCreateDto newPost)
		{
			var result = await _postService.CreateNewAsync(newPost);
			return Json( result );
		}

		[HttpPost]
		[Route( "update" )]
		public async Task<IActionResult> EditPost( [FromBody] PostCreateDto newPost )
		{
			var result = await _postService.UpdateAsync( newPost );
			return Json( result );
		}
	}
}
