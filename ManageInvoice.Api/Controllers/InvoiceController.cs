using MediatR;
using ManageInvoice.Application.CQRS.Invoices.Commands;
using ManageInvoice.Application.CQRS.Invoices.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ManageInvoice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command)
        {
            // 1) HTTP client sends POST /api/invoice with JSON body matching CreateInvoiceCommand
            // 2) ASP.NET model binding deserializes the body into CreateInvoiceCommand
            // 3) Controller forwards the command to MediatR: _mediator.Send(command)
            //    - MediatR resolves the CreateInvoiceCommandHandler
            // 4) Handler creates a new Invoice entity (Id, Number, Amount, CreatedAt)
            // 5) Handler calls IInvoiceCommandRepository.AddAsync(invoice) to stage the insert
            // 6) Handler calls IInvoiceCommandRepository.SaveChangesAsync() which triggers EF Core to persist to the database
            // 7) Handler returns the newly created invoice Id (Guid) back to the controller
            // 8) Controller returns 201 Created with a Location pointing to GET /api/invoice/{id}

            var invoiceId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = invoiceId }, invoiceId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(Guid id)
        {
            var query = new GetInvoiceByIdQuery(id);
            var invoice = await _mediator.Send(query);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }
    }
}
