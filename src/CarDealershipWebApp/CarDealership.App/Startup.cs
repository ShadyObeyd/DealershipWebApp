using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CarDealership.Models.DataModels;
using CarDealership.Data;
using CarDealership.App.Middlewares;
using CarDealership.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using System.IO;
using CarDealership.Utilities;

namespace CarDealership.App
{
    public class Startup
    {
        private const int RequiredPasswordLength = 3;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<DealershipDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

            services.AddIdentity<DealershipUser, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = RequiredPasswordLength;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<DealershipDbContext>();

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            services.AddRouting();

            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), Constants.RootDirectory)));

            services.AddMvc(opt =>
            {
                opt.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Application Services

            services.AddScoped<NewsService>();
            services.AddScoped<UserService>();
            services.AddScoped<CommentsService>();
            services.AddScoped<CarAddsService>();
            services.AddScoped<AddsService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.SeedData();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Users}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}