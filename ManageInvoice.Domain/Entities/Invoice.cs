using System;

namespace ManageInvoice.Domain.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
