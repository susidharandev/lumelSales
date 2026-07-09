namespace lumelSales.Models
{
    public class OrderItem
    {
        public int Id { get; set; } //pk
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public int QuantitySold { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }


    }
}
