using Microsoft.AspNetCore.Identity;
using System;

namespace CarDealership.Models.DataModels
{
    public class DealershipUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }
    }
}
