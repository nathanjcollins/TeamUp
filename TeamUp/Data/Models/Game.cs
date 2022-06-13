namespace TeamUp.Data.Models;

public class Game : BaseEntity
{
    public virtual ICollection<GamePlatform> GamePlatforms { get; set; } = null!;

    public virtual ICollection<Rank> Ranks { get; set; } = null!;

    public virtual ICollection<Position> Positions { get; set; } = null!;
}