using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository
{
    [Table("Customers")]
    public class CustomerEntity
    {
        [Key]
        public string CustomerName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public decimal? BillAmount { get; set; }
        public DateTime? BillDate { get; set; }
        public string? Address { get; set; }
        public string? CustomerType { get; set; }
    }
}
