using AutoMapper;
using Blog.Core;
using Blog.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Dal.Infrastructure
{
	public class ApplicationMapperConfig : Profile
	{
		public ApplicationMapperConfig ()
		{
			ConfigureAuthorMapping();
		}

		private void ConfigureAuthorMapping ()
		{

			#region Blog

			CreateMap<BlogEntity, BlogDto>();

			CreateMap<BlogDto, BlogEntity>()
				.ForMember(e => e.Id, options => options.Ignore());

			CreateMap<BlogEntity, BlogInListDto>();

			#endregion

			#region User

			CreateMap<User, UserDto>();
			CreateMap<UserDto, User>()
				.ForMember(e => e.Id, options => options.Ignore())
				.ForMember(e => e.PasswordHash, options => options.MapFrom(x => x.Password));

			#endregion


		}
	}
}
