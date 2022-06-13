using System.ComponentModel.DataAnnotations;

namespace TeamUp.Data.Models;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }

    public bool IsDeleted { get; set; } = false;
    
    public string Name { get; set; }
}