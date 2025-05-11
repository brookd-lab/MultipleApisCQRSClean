using First.Domain;
using MediatR;

namespace First.Features.Products.Commands.Update
{
    public record UpdateProductCommand(Product product) : IRequest;
}
