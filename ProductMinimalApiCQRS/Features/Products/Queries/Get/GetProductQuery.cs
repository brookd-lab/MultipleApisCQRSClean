using First.Features.Products.DTOs;
using MediatR;

namespace First.Features.Products.Queries.Get
{
    public record GetProductQuery(Guid Id) : IRequest<ProductDto>;
}
