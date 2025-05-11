using First.Features.Products.DTOs;
using First.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace First.Features.Products.Queries.List
{
    public class ListProductsQueryHandler(AppDbContext context) : IRequestHandler<ListProductsQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            return await context.Products
                .Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price))
                .ToListAsync();
        }
    }
}
