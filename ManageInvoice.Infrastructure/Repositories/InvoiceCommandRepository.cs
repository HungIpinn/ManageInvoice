using ManageInvoice.Application.Interfaces;
using ManageInvoice.Domain.Entities;
using ManageInvoice.Infrastructure.Data;
using System.Threading.Tasks;

namespace ManageInvoice.Infrastructure.Repositories
{
    public class InvoiceCommandRepository : IInvoiceCommandRepository
    {
        private readonly AppDbContext _context;

        public InvoiceCommandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
