using Api.Entities.Abstract;

namespace Api.Entities;

public class UserEntity : BaseEntity
{
    public string Email { get; set; }

    public HashSet<ImageEntity> VisitedImages { get; set; } = new HashSet<ImageEntity>();
}
