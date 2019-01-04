using CarDealership.Utilities;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.Adds.CarAdds
{
    public class CarAddInputModel
    {
        private const string CarMakeDisplayStr = "Make";
        private const string CarModelDisplayStr = "Model";
        private const string CarHorsePowerDisplayStr = "Horse Power";
        private const string CarColorDisplayStr = "Color";
        private const string CarCategoryDisplayStr = "Category";
        private const int CarMinHorsePower = 10;
        private const int CarMaxHorsePower = 2000;
        private const string CarExtrasDisplayStr = "Extras";
        private const string YearOfProductionDisplayStr = "Produced On";
        private const int StartYear = 1901;
        private const int EndYear = 2019;
        private const string CarLocationDisplayStr = "Location";
        private const string CarPriceDisplayStr = "Price";
        private const string CarTransmissionDisplayStr = "Transmission";
        private const string CarEngineTypeDisplayStr = "Engine Type";
        private const string AdditionalInfoDisplayStr = "Additional Info";

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = AdditionalInfoDisplayStr)]
        public string AdditionalInfo { get; set; }

        [Required]
        [Display(Name = CarMakeDisplayStr)]
        public string CarMake { get; set; }

        [Required]
        [Display(Name = CarModelDisplayStr)]
        public string CarModel { get; set; }

        [Display(Name = CarHorsePowerDisplayStr)]
        [Range(CarMinHorsePower, CarMaxHorsePower, ErrorMessage = Constants.CarHorsePowerErrorMessage)]
        public int CarHorsePower { get; set; }

        [Display(Name = CarColorDisplayStr)]
        public string CarColor { get; set; }

        [Display(Name = CarCategoryDisplayStr)]
        public string CarCategory { get; set; }

        [Required]
        [Display(Name = CarExtrasDisplayStr)]
        public string CarExtras { get; set; }

        [Required]
        [Display(Name = YearOfProductionDisplayStr)]
        [Range(StartYear, EndYear, ErrorMessage = Constants.CarYearOfProductionErrorMessage)]
        public int CarYearOfProduction { get; set; }

        [Required]
        [Display(Name = CarLocationDisplayStr)]
        public string CarLocation { get; set; }

        [Required]
        [Display(Name = CarPriceDisplayStr)]
        public decimal CarPrice { get; set; }

        [Required]
        [Display(Name = CarEngineTypeDisplayStr)]
        public string CarEngineType { get; set; }

        [Required]
        [Display(Name = CarTransmissionDisplayStr)]
        public string CarTransmission { get; set; }
    }
}