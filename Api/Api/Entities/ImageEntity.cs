using Api.Entities.Abstract;

namespace Api.Entities;

public class ImageEntity : BaseEntity
{
    public string LocalUrl { get; set; }
    public string SourceUrl { get; set; }

    public HashSet<UserEntity> UsersWhoVisited { get; set; } = new HashSet<UserEntity>();
}
