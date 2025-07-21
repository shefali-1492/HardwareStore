

using MediatR;

namespace BackOffice.Application.Products.Commands
{
   public record DeleteProductCommand(Guid Id) : IRequest<bool>;
}
