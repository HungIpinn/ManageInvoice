using ManageInvoice.Domain.Entities;
using System.Threading.Tasks;

namespace ManageInvoice.Application.Abstracts
{
    public abstract class InvoiceCommandRepositoryBase
    {
        // Abstract method (must be implemented by derived classes)
        public abstract Task AddAsync(Invoice invoice);

        // Abstract method (must be implemented by derived classes)
        public abstract Task<int> SaveChangesAsync();

        // Concrete method (optional for derived classes to override)
        public virtual Task LogAsync(string message)
        {
            // Default implementation for logging
            Console.WriteLine($"[LOG]: {message}");
            return Task.CompletedTask;
        }
    }
}
