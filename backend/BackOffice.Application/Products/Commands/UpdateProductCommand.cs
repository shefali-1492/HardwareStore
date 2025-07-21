using MediatR;

namespace BackOffice.Application.Products.Commands
{
    public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price, int Quantity) : IRequest<bool>;
}
