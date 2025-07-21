
using BackOffice.Domain.Entities;
using MediatR;

namespace BackOffice.Application.Products.Queries
{
    public record GetAllProductsQuery() : IRequest<List<Product>>;
}
