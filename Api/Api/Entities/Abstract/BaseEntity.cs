namespace Api.Entities.Abstract;

public abstract class BaseEntity : IEntity
{
    // unique key
    public Guid Id { get; set; }

    // properties
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}