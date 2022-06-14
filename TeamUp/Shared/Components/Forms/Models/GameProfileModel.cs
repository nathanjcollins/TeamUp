namespace TeamUp.Shared.Components.Forms.Models;

public class GameProfileModel
{
    public int? Id { get; set; }
    
    public int GameId { get; set; }
    
    public int RankId { get; set; }

    public int PlatformId { get; set; }

    public int[] PositionIds { get; set; } = null!;
}