using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TeamUp.Data.Models;

public class UserPosition : BaseLinkerEntity
{
    [ForeignKey("AspNetUser")]
    public string UserId { get; set; } = null!;
    public virtual IdentityUser User { get; set; } = null!;

    [ForeignKey("Position")]
    public int PositionId { get; set; }
    public virtual Position Position { get; set; } = null!;
}