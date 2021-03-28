using AutoMapper;
using Blog.Core;
using Blog.Core.Models;
using Blog.Core.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Dal.Infrastructure
{
	public class ApplicationMapperConfig : Profile
	{
		public ApplicationMapperConfig()
		{
			ConfigureAuthorMapping();
		}

		private void ConfigureAuthorMapping()
		{

			#region Blog

			CreateMap<BlogEntity, BlogDto>();

			CreateMap<BlogDto, BlogEntity>()
				.ForMember( e => e.Id, options => options.Ignore() )
				.ForMember( e => e.UserId, options => options.MapFrom( x => x.OwnerUserId ) )
				.AfterMap( ( s, d ) => d.CreationDate = DateTime.UtcNow );

			CreateMap<BlogCreateDto, BlogEntity>()
				.ForMember( e => e.Id, options => options.Ignore() )
				.ForMember( e => e.Name, options => options.MapFrom( x => x.BlogName ) )
				.ForMember( e => e.Comment, options => options.MapFrom( x => x.BlogComment ) )
				.AfterMap( ( s, d ) => d.CreationDate = DateTime.UtcNow );

			CreateMap<BlogEntity, BlogInListDto>()
				.ForMember( e => e.BlogName, options => options.MapFrom( x => x.Name ) )
				.ForMember( e => e.PostsCount, options => options.MapFrom( x => x.Posts.Count ) )
				.ForMember( e => e.BlogCreationDate, options => options.MapFrom( x => x.CreationDate ) )
				.ForMember( e => e.BlogShortComment, options => options.MapFrom( x => x.Comment.Substring(0, BlogConstants.SHORT_COMMENT_LENGTH ) ) )
				.AfterMap( ( s, d ) => d.BlogRating = 4 );

			#endregion

			#region User

			CreateMap<User, UserDto>();
			CreateMap<UserDto, User>()
				.ForMember( e => e.Id, options => options.Ignore() )
				.ForMember( e => e.PasswordHash, options => options.MapFrom( x => x.Password ) );
			CreateMap<UserSignUpDto, User>()
				.AfterMap( ( s, d ) => d.CreationDate = DateTime.UtcNow );

			CreateMap<User, UserProfileDto>()
				.ForMember( e => e.FullName, options => options.MapFrom( x => $"{x.FirstName} {x.LastName}" ) );
			#endregion


		}
	}
}
