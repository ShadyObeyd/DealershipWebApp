using CarDealership.Utilities;

namespace CarDealership.Models.ViewModels.Adds.CarAdds
{
    public class ViewCarAddsViewModel
    {
        private const int ContentLength = 30;

        public string Id { get; set; }

        public string Title { get; set; }

        public string PictureUrl { get; set; }

        public string AdditionalInfo { get; set; }

        public string AdditionalInfoToDisplay => this.GetAdditionAlInfoToDisplay();

        private string GetAdditionAlInfoToDisplay()
        {
            if (AdditionalInfo.Length > ContentLength)
            {
                return this.AdditionalInfo.Substring(0, ContentLength) + Constants.ThreeDots;
            }
            else
            {
                return this.AdditionalInfo;
            }
        }
    }
}
