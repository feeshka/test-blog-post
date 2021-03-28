using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Infrastructure
{
	public class HomeDalFacade : IHomeDalFacade
	{
		public HomeDalFacade( ApplicationDbContext context, IMapper mapper )
		{
			_context = context;
			_mapper = mapper;
		}

		protected readonly ApplicationDbContext _context;
		protected readonly IMapper _mapper;

		public async Task<IEnumerable<TopBlogInListDto>> GetTopBlogsAsync( int count )
		{
			return await _context.Blogs
							.Include( x => x.User )
							.Include( x => x.Posts )
							.Include( x => x.Rating )
							.OrderBy( x => x.Rating.Stars )
							.Take( count )
							.Select( x => _mapper.Map<TopBlogInListDto>( x ) )
							.ToListAsync();
		}

		public async Task<IEnumerable<TopPostInListDto>> GetTopPostsAsync( int count )
		{
			return await _context.Posts
							.Include( x => x.Blog )
							.Include( x => x.Rating )
							.OrderBy( x => x.Rating.Stars )
							.Take( count )
							.Select( x => _mapper.Map<TopPostInListDto>( x ) )
							.ToListAsync();
		}
	}
}
