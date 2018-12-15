namespace CarDealership.Models.DataModels.Contracts
{
    public interface ISellable
    {
        decimal Price { get; set; }

        string Location { get; set; }
    }
}
