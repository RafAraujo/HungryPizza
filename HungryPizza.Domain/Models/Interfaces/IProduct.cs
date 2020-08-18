namespace HungryPizza.Domain.Models.Interfaces
{
    public interface IProduct
    {
        int ProductId { get; set; }

        Product Product { get; set; }

        decimal CalculatePrice();
    }
}
