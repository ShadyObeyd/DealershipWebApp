using CarDealership.Data;
using CarDealership.Models.DataModels;
using CarDealership.Models.ViewModels.Users;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealership.Services
{
    public class UserService
    {
        private readonly UserManager<DealershipUser> userManager;

        public UserService(UserManager<DealershipUser> userManager)
        {
            this.userManager = userManager;
        }

        public List<AllUsersViewModel> GetAllUsers(string signedInUserUsername)
        {
            var dbUsers = this.userManager.Users.Where(u => u.UserName != signedInUserUsername);

            var users = new List<AllUsersViewModel>();

            foreach (var user in dbUsers)
            {
                var userModel = new AllUsersViewModel
                {
                    Id = user.Id,
                    Username = user.UserName
                };

                if (this.userManager.IsInRoleAsync(user, Constants.AdminRole).Result)
                {
                    userModel.Role = Constants.AdminRole;
                }
                else
                {
                    userModel.Role = Constants.UserRole;
                }

                users.Add(userModel);
            }

            return users;
        }
    }
}
