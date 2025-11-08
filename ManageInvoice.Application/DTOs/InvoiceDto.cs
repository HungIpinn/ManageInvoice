using System;

namespace ManageInvoice.Application.DTOs
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
