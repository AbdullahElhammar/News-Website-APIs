
using NewsSystem.DAL;
using System.ComponentModel.DataAnnotations;

namespace NewsSystem.BL;

public class AuthorReadDetailsDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public ICollection<NewsChildDto> News { get; set; } = new HashSet<NewsChildDto>();
}
