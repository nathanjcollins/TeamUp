namespace TeamUp.Data.Models;

public class Platform : BaseEntity
{
    public ICollection<GamePlatform> GamePlatforms { get; set; } = null!;
}