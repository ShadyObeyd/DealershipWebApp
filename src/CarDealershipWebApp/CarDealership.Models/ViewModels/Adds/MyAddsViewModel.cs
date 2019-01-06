using CarDealership.Models.ViewModels.Adds.CarAdds;
using CarDealership.Models.ViewModels.Adds.MotorcycleAdds;
using CarDealership.Models.ViewModels.Adds.TruckAdds;
using System.Collections.Generic;

namespace CarDealership.Models.ViewModels.Adds
{
    public class MyAddsViewModel
    {
        public ICollection<ViewCarAddsViewModel> CarAdds { get; set; }

        public ICollection<ViewTruckAddsViewModel> TruckAdds { get; set; }

        public ICollection<ViewMotorcycleAddsViewModel> MotorcycleAdds { get; set; }
    }
}