namespace CarDealership.Models.DataModels.Contracts
{
    public interface ISellable
    {
        decimal PriceFrom { get; set; }

        decimal PriceTo { get; set; }

        string Location { get; set; }
    }
}
