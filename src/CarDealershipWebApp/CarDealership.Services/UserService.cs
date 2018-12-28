using CarDealership.Models.DataModels;
using CarDealership.Models.ViewModels.Users;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System;
using CarDealership.Models.ViewModels.Errors;

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
            var dbUsers = this.userManager.Users.Where(u => u.UserName != signedInUserUsername && u.IsDeleted == false);

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

        public void PromoteUser(DealershipUser user)
        {
            this.CheckUser(user);

            this.userManager.RemoveFromRoleAsync(user, Constants.UserRole).Wait();
            this.userManager.AddToRoleAsync(user, Constants.AdminRole).Wait();
        }

        public void DemoteAdmin(DealershipUser user)
        {
            this.CheckUser(user);

            this.userManager.RemoveFromRoleAsync(user, Constants.AdminRole).Wait();
            this.userManager.AddToRoleAsync(user, Constants.UserRole).Wait();
        }

        public DealershipUser GetUserById(string id)
        {
            var user = this.userManager.Users.FirstOrDefault(u => u.Id == id);

            return user;
        }

        public ErrorViewModel GetErrorModel()
        {
            return new ErrorViewModel
            {
                Message = Constants.InvalidUserMessage
            };
        }

        private void CheckUser(DealershipUser user)
        {
            if (user == null)
            {
                throw new ArgumentException();
            }
        }
    }
}
