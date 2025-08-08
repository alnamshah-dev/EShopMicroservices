namespace Ordering.Domain.Abstracts;
public interface IAggregate<T> :  IAggregate,IEntity<T>
{
}
public interface IAggregate:IEntity
{
    IReadOnlyList<IDomainEvent> Events { get; }
    IDomainEvent[] ClearDomainEvents();
}