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

			CreateMap<BlogEntity, BlogDto>()
				.ForMember( e => e.CreationDate, options => options.MapFrom( x => x.CreationDate.ToString( "dd-MM-yyyy" ) ) )
				.ForMember( e => e.Rating, options => options.MapFrom( x => x.Rating.Stars ) )
				.ForMember( e => e.OwnerUserName, options => options.MapFrom( x => x.User.UserName ) )
				.ForMember( e => e.PostsCount, options => options.MapFrom( x => x.Posts.Count ) )
				.ForMember( e => e.OwnerUserId, options => options.MapFrom( x => x.User.Id ) );

			CreateMap<BlogDto, BlogEntity>()
				.ForMember( e => e.Id, options => options.Ignore() )
				.ForMember( e => e.UserId, options => options.MapFrom( x => x.OwnerUserId ) )
				.AfterMap( ( s, d ) => d.CreationDate = DateTime.UtcNow );

			CreateMap<BlogEntity, BlogSelectItemDto>();

			CreateMap<BlogCreateDto, BlogEntity>()
				.ForMember( e => e.Id, options => options.Ignore() )
				.ForMember( e => e.Name, options => options.MapFrom( x => x.BlogName ) )
				.ForMember( e => e.Comment, options => options.MapFrom( x => x.BlogComment ) )
				.AfterMap( ( s, d ) => d.CreationDate = DateTime.UtcNow )
				.AfterMap( ( s, d ) => d.Rating = new BlogRating() );

			CreateMap<BlogEntity, BlogInListDto>()
				.ForMember( e => e.BlogName, options => options.MapFrom( x => x.Name ) )
				.ForMember( e => e.PostsCount, options => options.MapFrom( x => x.Posts.Count ) )
				.ForMember( e => e.BlogCreationDate, options => options.MapFrom( x => x.CreationDate ) )
				.ForMember( e => e.BlogShortComment, options => options.MapFrom( x => x.Comment.Substring(0, BlogConstants.SHORT_COMMENT_LENGTH ) ) )
				.ForMember( e => e.BlogOwnerName, options => options.MapFrom( x => x.User.UserName ) )
				.AfterMap( ( s, d ) => d.BlogRating = 4 );

			#endregion

			#region Post

			CreateMap<Post, PostDto>()
				.ForMember( e => e.CreationDate, options => options.MapFrom( x => x.CreationDate.ToString( "dd-MM-yyyy" ) ) );

			CreateMap<PostDto, Post>()
				.ForMember( e => e.Id, options => options.Ignore() )
				.ForMember( e => e.CreatorUserId, options => options.MapFrom( x => x.OwnerUserId ) )
				.AfterMap( ( s, d ) => d.CreationDate = DateTime.UtcNow );


			CreateMap<PostCreateDto, Post>()
				.ForMember( e => e.Id, options => options.Ignore() )
				.ForMember( e => e.Name, options => options.MapFrom( x => x.PostName ) )
				.ForMember( e => e.Content, options => options.MapFrom( x => x.PostComment ) )
				.ForMember( e => e.CreatorUserId, options => options.MapFrom( x => x.OwnerUserId ) )
				.AfterMap( ( s, d ) => d.Rating = new PostsRating() )
				.AfterMap( ( s, d ) => d.CreationDate = DateTime.UtcNow );

			CreateMap<Post, PostInListDto>()
				.ForMember( e => e.PostName, options => options.MapFrom( x => x.Name ) )
				.ForMember( e => e.PostCreationDate, options => options.MapFrom( x => x.CreationDate ) )
				.ForMember( e => e.PostOwnerName, options => options.MapFrom( x => x.CreatorUser.UserName ) )
				.AfterMap( ( s, d ) => d.PostRating = 4 );

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

			#region Home

			CreateMap<BlogEntity, TopBlogInListDto>()
			.ForMember( e => e.BlogName, options => options.MapFrom( x => x.Name ) )
			.ForMember( e => e.PostsCount, options => options.MapFrom( x => x.Posts.Count ) )
			.ForMember( e => e.BlogCreationDate, options => options.MapFrom( x => x.CreationDate ) )
			.ForMember( e => e.BlogShortComment, options => options.MapFrom( x => x.Comment.Substring( 0, BlogConstants.SHORT_COMMENT_LENGTH ) ) )
			.ForMember( e => e.BlogOwner, options => options.MapFrom( x => x.User.UserName ) )
			.AfterMap( ( s, d ) => d.BlogRating = 4 );

			CreateMap<Post, TopPostInListDto>()
			.ForMember( e => e.PostName, options => options.MapFrom( x => x.Name ) )
			.ForMember( e => e.PostCreationDate, options => options.MapFrom( x => x.CreationDate ) )
			.ForMember( e => e.AuthorName, options => options.MapFrom( x => x.Blog.User.UserName ) )
			.AfterMap( ( s, d ) => d.PostRating = 4 );

			#endregion
		}
	}
}
