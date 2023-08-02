using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JolliTradersHope.Api.Data.Entities
{
    [Table(nameof(Address))]
    public class Address
    {
        [Key]
        public long Id { get; set; }
        public int UserId { get; set; }
        [Required, MaxLength(150)]
        public string Address1 { get; set; }
        [MaxLength(150)]
        public string? Address2 { get; set; }
        [Required, MaxLength(6)]
        public string Zip { get; set; }
        [Required, MaxLength(150)]
        public string? Name { get; set; }
        public bool IsPrimary { get; set; }
        public User User{ get; set; }
    }
}
