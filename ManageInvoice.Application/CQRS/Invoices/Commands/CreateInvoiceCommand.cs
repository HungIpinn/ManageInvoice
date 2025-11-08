using MediatR;
using System;

namespace ManageInvoice.Application.CQRS.Invoices.Commands
{
    public record CreateInvoiceCommand(string Number, decimal Amount) : IRequest<Guid>;
}
