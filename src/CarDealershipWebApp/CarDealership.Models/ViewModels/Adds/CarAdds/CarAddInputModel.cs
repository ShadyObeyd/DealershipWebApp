using CarDealership.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.Adds.CarAdds
{
    public class CarAddInputModel
    {
        private const string CarMakeDisplayStr = "Make";
        private const string CarModelDisplayStr = "Model";
        private const string CarColorDisplayStr = "Color";
        private const string CarCategoryDisplayStr = "Category";
        private const string CarExtrasDisplayStr = "Extras";
        private const string YearOfProductionDisplayStr = "Produced On";
        private const string CarLocationDisplayStr = "Location";
        private const string CarPriceDisplayStr = "Price";
        private const string CarTransmissionDisplayStr = "Transmission";
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

        [Required]
        [Display(Name = Constants.CarHorsePowerDisplayStr)]
        [Range(Constants.CarMinHorsePower, Constants.CarMaxHorsePower, ErrorMessage = Constants.CarHorsePowerErrorMessage)]
        public int CarHorsePower { get; set; }

        [Required]
        [Display(Name = CarColorDisplayStr)]
        public string CarColor { get; set; }

        [Required]
        [Display(Name = CarCategoryDisplayStr)]
        public string CarCategory { get; set; }

        [Required]
        [Display(Name = CarExtrasDisplayStr)]
        public string CarExtras { get; set; }

        [Required]
        [Display(Name = YearOfProductionDisplayStr)]
        [Range(Constants.YearMinValue, Constants.YearMaxValue, ErrorMessage = Constants.CarYearOfProductionErrorMessage)]
        public int CarYearOfProduction { get; set; }

        [Required]
        [Display(Name = CarLocationDisplayStr)]
        public string CarLocation { get; set; }

        [Required]
        [Display(Name = CarPriceDisplayStr)]
        [Range(typeof(decimal), Constants.PriceMinValue, Constants.PriceMaxValue, ErrorMessage = Constants.PriceErrorMessage)]
        public decimal CarPrice { get; set; }

        [Required]
        [Display(Name = Constants.CarEngineTypeDisplayStr)]
        public string CarEngineType { get; set; }

        [Required]
        [Display(Name = CarTransmissionDisplayStr)]
        public string CarTransmission { get; set; }

        [Required]
        public List<IFormFile> Pictures { get; set; }
    }
}