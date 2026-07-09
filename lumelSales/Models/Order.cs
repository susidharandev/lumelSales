using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lumelSales.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; } //pk
        public string Region { get; set; }
        public DateTime DateofSale { get; set; }
        public decimal ShippingCost { get; set; }
        public string PaymentMethod { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
