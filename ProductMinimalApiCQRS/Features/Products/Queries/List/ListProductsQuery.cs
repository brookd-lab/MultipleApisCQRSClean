using First.Features.Products.DTOs;
using MediatR;

namespace First.Features.Products.Queries.List
{
    public record ListProductsQuery : IRequest<List<ProductDto>>;
}
