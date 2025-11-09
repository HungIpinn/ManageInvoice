using System;

namespace ManageInvoice.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
