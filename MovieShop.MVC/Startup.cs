using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Infrastructure.Repositories;
using MovieShop.Infrastructure.Services;
using MovieShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieShop.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // DI(dependency injection)
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // registering our Classes for interfaced to be used across our applicattion
            //.NET Core has build-in DI
            // old verse of >net Framwork did not had build-in DI, we had to download 3rd party package or IOC,like Ninject, Autofac
            //
            //
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddDbContext<MovieShopDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("MovieShopDbConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting(); // order is important, is sth is missing, the request might break. 

            app.UseAuthorization();

            app.UseEndpoints(endpoints => // when you do not mention anything after the domain, it will by default set to Home/index route; if you did not mention action it will displace index as default.
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
