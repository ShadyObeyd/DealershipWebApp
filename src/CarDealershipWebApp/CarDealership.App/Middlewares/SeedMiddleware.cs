using CarDealership.Models.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CarDealership.Utilities;

namespace CarDealership.App.Middlewares
{
    public class SeedMiddleware
    {
        private const string AdminUsername = "pesho@pesho.bg";
        private const string AdminEmail = "pesho@pesho.bg";
        private const string AdminFirstName = "Peter";
        private const string AdminLastName = "Petrov";
        private const string AdminPassword = "123456";

        private readonly RequestDelegate next;

        public SeedMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IServiceProvider serviceProvider, SignInManager<DealershipUser> signInManager)
        {
            // Seed Roles
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            var adminRoleExists = roleManager.RoleExistsAsync(Constants.AdminRole).Result;

            if (!adminRoleExists)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.AdminRole));
            }

            var userRoleExists = roleManager.RoleExistsAsync(Constants.UserRole).Result;

            if (!userRoleExists)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.UserRole));
            }

            // Seed User admin
            if (!signInManager.UserManager.Users.Any())
            {
                var user = new DealershipUser
                {
                    UserName = AdminUsername,
                    Email = AdminEmail,
                    FirstName = AdminFirstName,
                    LastName = AdminLastName,
                    RegisteredOn = DateTime.Now
                };

                var result = signInManager.UserManager.CreateAsync(user, AdminPassword).Result;

                var roleResult = signInManager.UserManager.AddToRoleAsync(user, Constants.AdminRole).Result;
            }

            await this.next(httpContext);
        }
    }
}