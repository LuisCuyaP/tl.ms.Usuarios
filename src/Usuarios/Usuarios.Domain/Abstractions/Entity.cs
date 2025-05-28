
namespace Usuarios.Domain.Abstractions;

public abstract class Entity
{
    private readonly List<IDomainEvent> events = new();
    public Guid Id { get; set; }
    public void RaiseEvent(IDomainEvent domainEvent)
    {
        if (domainEvent == null)
        {
            throw new ArgumentNullException(nameof(domainEvent));
        }
        events.Add(domainEvent);
    }
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return events.ToList();
    }
    public void ClearDomainEvents()
    {
        events.Clear();
    }
}
