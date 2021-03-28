using Blog.Application.Services;
using Blog.Core;
using Blog.Core.Infrastructure;
using Blog.Application.Services.Infrastructure;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure.IoC
{
	public class DependencyContainer
	{
		public static void RegisterServices (IServiceCollection services)
		{
			services.AddScoped<IBlogDalFacade, BlogDalFacade>();
			services.AddScoped<IBlogService, BlogService>();
			services.AddScoped<IUserAuthService, UserAuthService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IUserAuthDalFacade, UserAuthDalFacade>();
			services.AddScoped<IUserDalFacade, UserDalFacade>();
			services.AddScoped<IHomeDalFacade, HomeDalFacade>();
			services.AddScoped<IHomeService, HomeService>();
			services.AddScoped<IPostDalFacade, PostDalFacade>();
			services.AddScoped<IPostService, PostService>();


		}
	}
}
