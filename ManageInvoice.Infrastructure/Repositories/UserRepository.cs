using ManageInvoice.Domain.Entities;
using ManageInvoice.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace ManageInvoice.Infrastructure.Repositories
{
    internal class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // Placeholder for user operations
    }
}
