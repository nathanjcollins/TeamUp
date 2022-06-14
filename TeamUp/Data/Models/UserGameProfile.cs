using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TeamUp.Data.Models;

public class UserGameProfile : BaseEntity
{
    [ForeignKey("Rank")]
    public int? RankId { get; set; }
    public virtual Rank? Rank { get; set; }
    
    [ForeignKey("AspNetUser")]
    public string UserId { get; set; } = null!;
    public virtual IdentityUser User { get; set; } = null!;
    
    public virtual ICollection<Position>? Positions { get; set; } = null!;
}