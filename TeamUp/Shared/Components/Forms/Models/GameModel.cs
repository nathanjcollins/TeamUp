namespace TeamUp.Shared.Components.Forms.Models;

public class GameModel
{
    public int? Id { get; set; }
    
    public string Name { get; set; } = null!;

    public int[] PlatformIds { get; set; } = null!;
}