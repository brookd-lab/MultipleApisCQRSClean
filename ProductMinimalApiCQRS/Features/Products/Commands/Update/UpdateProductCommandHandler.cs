using First.Persistence;
using MediatR;

namespace First.Features.Products.Commands.Update
{
    public class UpdateProductCommandHandler(AppDbContext context) : IRequestHandler<UpdateProductCommand>
    {
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.product.Id);
            if (product == null) return;
            product.Name = request.product.Name;
            product.Description = request.product.Description;
            product.Price = request.product.Price;
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
