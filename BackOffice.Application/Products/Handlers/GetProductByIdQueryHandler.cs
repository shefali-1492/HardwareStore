

using BackOffice.Application.Products.Queries;
using BackOffice.Domain.Entities;
using BackOffice.Domain.Interfaces;
using MediatR;

namespace BackOffice.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _repo;
        public GetProductByIdQueryHandler(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIdAsync(request.Id);
        }
    }
   
}
