
using BackOffice.Application.Products.Queries;
using BackOffice.Domain.Entities;
using BackOffice.Domain.Interfaces;
using MediatR;

namespace BackOffice.Application.Products.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProductRepository _repo;

        public GetAllProductsQueryHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _repo.GetAllAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                // You can use a logging framework like Serilog, NLog, etc.
                throw new ApplicationException("An error occurred while retrieving products.", ex);
            }
        }
    }
}
