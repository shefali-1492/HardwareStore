

using BackOffice.Application.Products.Commands;
using BackOffice.Domain.Interfaces;
using BackOffice.Domain.Entities;
using MediatR;

namespace BackOffice.Application.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _repo; // Assuming a repository interface for Product

        public CreateProductCommandHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity
            };

            await _repo.AddAsync(product);
            return product.Id; // Return the actual product ID
        }
    }
    
}
