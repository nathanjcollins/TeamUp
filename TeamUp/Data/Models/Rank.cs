using System.ComponentModel.DataAnnotations.Schema;

namespace TeamUp.Data.Models;

public class Rank : BaseEntity
{
    [ForeignKey("Game")]
    public int GameId { get; set; }
    public virtual Game Game { get; set; } = null!;
}