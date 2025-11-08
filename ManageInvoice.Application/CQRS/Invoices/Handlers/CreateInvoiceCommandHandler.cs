using MediatR;
using ManageInvoice.Application.CQRS.Invoices.Commands;
using ManageInvoice.Application.Interfaces;
using ManageInvoice.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ManageInvoice.Application.CQRS.Invoices.Handlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Guid>
    {
        private readonly IInvoiceCommandRepository _commandRepository;

        public CreateInvoiceCommandHandler(IInvoiceCommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<Guid> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                Number = request.Number,
                Amount = request.Amount,
                CreatedAt = DateTime.UtcNow
            };

            await _commandRepository.AddAsync(invoice);
            await _commandRepository.SaveChangesAsync();

            return invoice.Id;
        }
    }
}
