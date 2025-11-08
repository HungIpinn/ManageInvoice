using MediatR;
using ManageInvoice.Application.DTOs;
using System;

namespace ManageInvoice.Application.CQRS.Invoices.Queries
{
    public record GetInvoiceByIdQuery(Guid Id) : IRequest<InvoiceDto?>;
}
