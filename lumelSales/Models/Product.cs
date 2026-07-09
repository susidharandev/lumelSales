namespace lumelSales.Models
{
    public class Product
    {
        public string ProductId { get; set; } //pk
        public string ProductName { get; set; }
        public string Category { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
