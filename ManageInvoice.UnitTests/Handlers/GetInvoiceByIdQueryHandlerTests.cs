using ManageInvoice.Application.CQRS.Invoices.Handlers;
using ManageInvoice.Application.CQRS.Invoices.Queries;
using ManageInvoice.Application.DTOs;
using ManageInvoice.Application.Interfaces;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ManageInvoice.UnitTests.Handlers
{
    public class GetInvoiceByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnInvoiceDto_WhenInvoiceExists()
        {
            // Arrange
            var mockRepository = new Mock<IInvoiceQueryRepository>();
            var handler = new GetInvoiceByIdQueryHandler(mockRepository.Object);

            var query = new GetInvoiceByIdQuery(Guid.NewGuid());
            var expectedInvoice = new InvoiceDto
            {
                Id = query.Id,
                Number = "INV-001",
                Amount = 1000,
                CreatedAt = DateTime.UtcNow
            };

            mockRepository.Setup(r => r.GetByIdAsync(query.Id)).ReturnsAsync(expectedInvoice);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedInvoice.Id, result.Id);
            mockRepository.Verify(r => r.GetByIdAsync(query.Id), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnNull_WhenInvoiceDoesNotExist()
        {
            // Arrange
            var mockRepository = new Mock<IInvoiceQueryRepository>();
            var handler = new GetInvoiceByIdQueryHandler(mockRepository.Object);

            var query = new GetInvoiceByIdQuery(Guid.NewGuid());

            mockRepository.Setup(r => r.GetByIdAsync(query.Id)).ReturnsAsync((InvoiceDto?)null);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Null(result);
            mockRepository.Verify(r => r.GetByIdAsync(query.Id), Times.Once);
        }
    }
}