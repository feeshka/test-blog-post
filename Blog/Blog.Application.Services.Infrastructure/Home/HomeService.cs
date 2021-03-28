using Blog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.Infrastructure
{
	public class HomeService : IHomeService
	{
		public HomeService( IHomeDalFacade homeDalFacade )
		{
			_homeDalFacade = homeDalFacade;
		}

		private readonly IHomeDalFacade _homeDalFacade;
		public Task<IEnumerable<TopBlogInListDto>> GetTopBlogsAsync( int count )
		{
			return _homeDalFacade.GetTopBlogsAsync( count );
		}

		public Task<IEnumerable<TopPostInListDto>> GetTopPostsAsync( int count )
		{
			return _homeDalFacade.GetTopPostsAsync( count );
		}
	}
}
