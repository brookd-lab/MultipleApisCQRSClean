using MediatR;

namespace First.Features.Products.Commands.Delete
{
    public record DeleteProductCommand(Guid Id) : IRequest;
}
