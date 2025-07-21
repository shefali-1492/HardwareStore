using BackOffice.Application.Products.Commands;
using BackOffice.Application.Products.Queries;
using MediatR;

namespace BackOffice.API.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/products", async (ISender sender) =>
            {
                var products = await sender.Send(new GetAllProductsQuery());
                return Results.Ok(products);
            });

            app.MapGet("/api/products/{id:guid}", async (Guid id, ISender sender) =>
            {
                var product = await sender.Send(new GetProductByIdQuery(id));
                return product is not null ? Results.Ok(product) : Results.NotFound();
            });

            app.MapPost("/api/products", async (CreateProductCommand command, ISender sender) =>
            {
                var id = await sender.Send(command);
                return Results.Created($"/api/products/{id}", id);
            });

            app.MapPut("/api/products/{id:guid}", async (Guid id, UpdateProductCommand command, ISender sender) =>
            {
                if (id != command.Id) return Results.BadRequest();
                var result = await sender.Send(command);
                return result ? Results.NoContent() : Results.NotFound();
            });

            app.MapDelete("/api/products/{id:guid}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id));
                return result ? Results.NoContent() : Results.NotFound();
            });
        }
    }
}
