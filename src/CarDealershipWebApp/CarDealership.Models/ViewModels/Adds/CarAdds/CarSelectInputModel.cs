using CarDealership.Utilities;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.Adds.CarAdds
{
    public class CarSelectInputModel
    {
        private const string StartingPriceStr = "Price from";
        private const string EndPriceStr = "Price to";
        private const string StartingYearStr = "Year from";
        private const string EndYearStr = "Year to";

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Display(Name = StartingPriceStr)]
        public decimal StartingPrice { get; set; }

        [Display(Name = EndPriceStr)]
        public decimal EndPrice { get; set; }

        [Required]
        [Display(Name = Constants.CarEngineTypeDisplayStr)]
        public string EngineType { get; set; }

        [Required]
        public string Transmission { get; set; }

        [Required]
        public string Category { get; set; }

        [Display(Name = StartingYearStr)]
        public int StartingYear { get; set; }

        [Display(Name = EndYearStr)]
        public int EndYear { get; set; }

        [Required]
        [Display(Name = Constants.CarHorsePowerDisplayStr)]
        [Range(Constants.CarMinHorsePower, Constants.CarMaxHorsePower, ErrorMessage = Constants.CarHorsePowerErrorMessage)]
        public int HorsePower { get; set; }

        public string Location { get; set; }
    }
}
