using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration;
public class BasketCheckoutEventHandler(ISender sender,ILogger<BasketCheckoutEventHandler> logger) : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration Event Handled : {IntegrationEvent}", context.Message.GetType().Name);
        var command = MapToCreateOrderCommand(context.Message);
        await sender.Send(command);
    }
    private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent Message)
    {
        var addressDto=new AddressDto(Message.FirstName, Message.LastName,Message.EmailAddress,Message.AddressLine,Message.Country,Message.State,Message.ZipCode);
        var paymentDto = new PaymentDto(Message.CardName, Message.CardNumber, Message.Expiration, Message.CVV, Message.PaymentMethod);
        Guid OrderId = Guid.NewGuid();
        var order = new OrderDto(
            Id:OrderId,
            CustomerId: Message.CustomerId,
            OrderName:Message.UserName,
            ShippingAddress: addressDto,
            BillingAddress:addressDto,
            Payment : paymentDto,
            Status: Ordering.Domain.Enums.OrderStatus.Pending,
            OrderItems: [
                new OrderItemDto(OrderId,new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),2,1200),
                new OrderItemDto(OrderId,new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),1,1300)
                ]
            );
        return new CreateOrderCommand(order);
    }
}
