
using BackOffice.Domain.Entities;
using MediatR;

namespace BackOffice.Application.Products.Queries
{
   public record GetProductByIdQuery(Guid Id) : IRequest<Product>;
}
