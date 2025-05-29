
namespace Usuarios.Domain.Abstractions;

public abstract class Entity
{
    private readonly List<IDomainEvent> events = new();
    protected Entity(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be empty.", nameof(id));
        }
        Id = id;
    }
    public Guid Id { get; set; }
    public void RaiseDomainEvent(IDomainEvent domainEvent)
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
