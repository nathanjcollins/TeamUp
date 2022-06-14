using System.ComponentModel.DataAnnotations;

namespace TeamUp.Shared.Components.Forms.Models;

public class PlatformModel
{
    public int? Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}