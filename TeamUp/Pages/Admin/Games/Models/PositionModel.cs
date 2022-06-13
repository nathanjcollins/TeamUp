using System.ComponentModel.DataAnnotations;

namespace TeamUp.Pages.Admin.Games.Models;

public class PositionModel
{
    public int? Id { get; set; }

    public int GameId { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}