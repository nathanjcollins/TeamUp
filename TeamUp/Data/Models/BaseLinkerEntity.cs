using System.ComponentModel.DataAnnotations;

namespace TeamUp.Data.Models;

public class BaseLinkerEntity
{
    [Key]
    public int Id { get; set; }

    public bool IsDeleted { get; set; } = false;
}