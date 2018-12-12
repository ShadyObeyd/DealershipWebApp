using Microsoft.AspNetCore.Identity;

namespace CarDealership.Models.DataModels
{
    public class DealershipUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}
