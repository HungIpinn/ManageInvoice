using ManageInvoice.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace ManageInvoice.Application.Interfaces
{
    public interface IInvoiceQueryRepository
    {
        Task<InvoiceDto?> GetByIdAsync(Guid id);
    }
}
