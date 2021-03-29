using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Core.Infrastructure;
using Blog.Core.Models;
using Blog.Infrastructure.IoC;
using Library.Dal.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Blog.Api
{
	public class Startup
	{
		public Startup( IConfiguration configuration )
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices( IServiceCollection services )
		{
			var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
			services.Configure<ApplicationSettings>( Configuration.GetSection( "ApplicationSettings" ) );
			services.AddControllers();
			services.AddCors();
			DependencyContainer.RegisterServices( services );

			#region Mapper

			var mapperConfig = new MapperConfiguration( mc =>
			 {
				 mc.AddProfile( new ApplicationMapperConfig() );
			 } );

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton( mapper );

			#endregion

			services.AddDbContext<ApplicationDbContext>( options =>
				 options.UseNpgsql(connectionString)
			);

			services.AddDefaultIdentity<User>()
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.Configure<IdentityOptions>( options =>
			 {
				 options.Password.RequireNonAlphanumeric = false;
				 options.Password.RequiredLength = 8;
				 options.Password.RequireDigit = false;
				 options.Password.RequireLowercase = false;
				 options.Password.RequireUppercase = false;
			 } );

			//Jbt Auth
			services.AddAuthentication( options =>
			 {
				 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				 options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			 } )
				.AddJwtBearer( options => 
				{
					options.RequireHttpsMetadata = false;
					options.SaveToken = false;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						IssuerSigningKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( Configuration["ApplicationSettings:SecretKey"].ToString() ) ),
						ValidateIssuerSigningKey = true,
						ValidateIssuer = false,
						ValidateAudience = false,
						ClockSkew = TimeSpan.Zero
					};
				} );

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
		{
			if ( env.IsDevelopment() )
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseCors( builder =>
			 {
				 builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
			 } );

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints( endpoints =>
			 {
				 endpoints.MapControllers();
			 } );
		}
	}
}
