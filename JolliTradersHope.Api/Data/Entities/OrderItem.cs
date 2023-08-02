using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JolliTradersHope.Api.Data.Entities
{
    [Table(nameof(OrderItem))]
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }
        public long OrderId { get; set; }
        public int ProductId { get; set; }
        [Required, MaxLength(100)]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
