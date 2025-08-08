namespace Ordering.Domain.Abstracts;
public interface IDomainEvent:INotification
{
    public Guid EventId=> Guid.NewGuid();
    public DateTime? OccurredOn=> DateTime.Now;
    public string EventType => GetType().AssemblyQualifiedName;
}
