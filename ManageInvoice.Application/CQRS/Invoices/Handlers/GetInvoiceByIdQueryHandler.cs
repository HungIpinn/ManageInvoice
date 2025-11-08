using MediatR;
using ManageInvoice.Application.CQRS.Invoices.Queries;
using ManageInvoice.Application.Interfaces;
using ManageInvoice.Application.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace ManageInvoice.Application.CQRS.Invoices.Handlers
{
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, InvoiceDto?>
    {
        private readonly IInvoiceQueryRepository _queryRepository;

        public GetInvoiceByIdQueryHandler(IInvoiceQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<InvoiceDto?> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetByIdAsync(request.Id);
        }
    }
}
