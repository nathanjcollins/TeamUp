using System.ComponentModel.DataAnnotations.Schema;

namespace TeamUp.Data.Models;

public class GamePlatform : BaseLinkerEntity
{
    [ForeignKey("Game")]
    public int GameId { get; set; }
    public virtual Game Game { get; set; } = null!;
    
    [ForeignKey("Platform")]
    public int PlatformId { get; set; }
    public virtual Platform Platform { get; set; } = null!;
}