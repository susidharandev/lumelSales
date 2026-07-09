namespace lumelSales.Models
{
    public class Customer
    {
        public string CustomerId { get; set; } //pk
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
