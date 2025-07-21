using BackOffice.Application.Products.Commands;
using BackOffice.Domain.Interfaces;
using MediatR;


namespace BackOffice.Application.Products.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _repo;

        public DeleteProductHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repo.GetByIdAsync(request.Id);
            if (product is null) return false;

            await _repo.DeleteAsync(request.Id);
            return true;
        }
    }
}
