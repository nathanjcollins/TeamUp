using System.ComponentModel.DataAnnotations.Schema;

namespace TeamUp.Data.Models;

public class Position: BaseEntity
{
    [ForeignKey("Game")]
    public int GameId { get; set; }
    public virtual Game Game { get; set; } = null!;

    public virtual ICollection<UserPosition> UserPositions { get; set; } = null!;
}