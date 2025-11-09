using ManageInvoice.Application.CQRS.Invoices.Commands;
using ManageInvoice.Application.CQRS.Invoices.Handlers;
using ManageInvoice.Application.Abstracts;
using ManageInvoice.Domain.Entities;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ManageInvoice.UnitTests.Handlers
{
    public class CreateInvoiceCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCallAddAsyncAndSaveChangesAsync()
        {
            // Arrange
            var mockRepository = new Mock<InvoiceCommandRepositoryBase>();
            mockRepository.Setup(r => r.AddAsync(It.IsAny<Invoice>())).Returns(Task.CompletedTask);
            mockRepository.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

            var handler = new CreateInvoiceCommandHandler(mockRepository.Object);

            var command = new CreateInvoiceCommand("INV-001", 1000);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            mockRepository.Verify(r => r.AddAsync(It.IsAny<Invoice>()), Times.Once);
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.IsType<Guid>(result);
        }
    }
}