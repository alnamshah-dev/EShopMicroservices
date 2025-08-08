namespace Ordering.Domain.Abstracts;
public abstract class Aggregate<TID> :  Entity<TID>,IAggregate<TID>
{
    private readonly List<IDomainEvent> _domainEvents=new();
    public IReadOnlyList<IDomainEvent> Events => _domainEvents.AsReadOnly();
    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    public IDomainEvent[] ClearDomainEvents()
    {
        IDomainEvent[] dequeuedEvents=_domainEvents.ToArray();
        _domainEvents.Clear();
        return dequeuedEvents;
    }
}
