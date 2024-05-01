using System.ComponentModel.DataAnnotations;

namespace NewsSystem.BL;

public class AuthorRead_Add_UpdateDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
}
