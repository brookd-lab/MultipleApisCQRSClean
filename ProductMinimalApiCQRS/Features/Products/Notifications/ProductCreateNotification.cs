using MediatR;

namespace First.Features.Products.Notifications
{
    public record ProductCreatedNotification(Guid Id) : INotification;
}
