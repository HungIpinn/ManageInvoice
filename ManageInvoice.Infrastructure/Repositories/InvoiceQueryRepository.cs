using ManageInvoice.Application.DTOs;
using ManageInvoice.Application.Interfaces;
using ManageInvoice.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ManageInvoice.Infrastructure.Repositories
{
    public class InvoiceQueryRepository : IInvoiceQueryRepository
    {
        private readonly AppDbContext _context;

        public InvoiceQueryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<InvoiceDto?> GetByIdAsync(Guid id)
        {
            return await _context.Invoices
                .AsNoTracking()
                .Where(i => i.Id == id)
                .Select(i => new InvoiceDto
                {
                    Id = i.Id,
                    Number = i.Number,
                    Amount = i.Amount,
                    CreatedAt = i.CreatedAt
                })
                .FirstOrDefaultAsync();
        }
    }
}
