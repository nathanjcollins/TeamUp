using System.ComponentModel.DataAnnotations.Schema;

namespace TeamUp.Data.Models;

public class UserGameProfilePosition : BaseLinkerEntity
{
    [ForeignKey("Position")]
    public int PositionId { get; set; }
    public virtual Position Position { get; set; } = null!;
    
    [ForeignKey("UserGameProfile")]
    public int UserGameProfileId { get; set; }
    public virtual UserGameProfile UserGameProfile { get; set; } = null!;
}