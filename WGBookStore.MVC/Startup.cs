using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WGBookStore.MVC.Data;
using WGBookStore.MVC.Interfaces;
using WGBookStore.MVC.Repositories;

namespace WGBookStore.MVC
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<BookStoreContext>(options =>
			   options.UseSqlServer(Configuration.GetConnectionString("BookStoreConnection")));
			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<BookStoreContext>();
			services.AddControllersWithViews();
			services.AddScoped<IBookRepository, BookRepository>();
			services.AddScoped<ILanguageRepository, LanguageRepository>();
			services.AddScoped<IAccountRepository, AccountRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
				//endpoints.MapControllerRoute(
				//	name: "Default",
				//	pattern: "bookApp/{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
