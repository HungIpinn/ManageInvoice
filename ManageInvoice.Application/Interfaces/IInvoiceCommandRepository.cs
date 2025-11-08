using ManageInvoice.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace ManageInvoice.Application.Interfaces
{
    public interface IInvoiceCommandRepository
    {
        Task AddAsync(Invoice invoice);
        Task<int> SaveChangesAsync();
    }
}
