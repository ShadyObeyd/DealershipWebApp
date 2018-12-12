using System;

namespace CarDealership.Models.DataModels
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
    }
}