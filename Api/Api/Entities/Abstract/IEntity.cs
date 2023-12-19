namespace Api.Entities.Abstract;

public interface IEntity
{
    // unique key
    Guid Id { get; set; }

    // properties
    DateTime CreatedOn { get; set; }
    DateTime ModifiedOn { get; set; }
}