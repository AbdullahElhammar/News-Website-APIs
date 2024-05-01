using System.ComponentModel.DataAnnotations;

namespace NewsSystem.BL;

public class ImageChildDto
{
    public int Id { get; set; }
    [Required]
    public string ImgUrl { get; set; } = string.Empty;
}
