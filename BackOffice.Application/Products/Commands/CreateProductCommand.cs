using MediatR;

namespace BackOffice.Application.Products.Commands
{
    public record CreateProductCommand(string Name, string Description, decimal Price, int Quantity) : IRequest<Guid>;

}
