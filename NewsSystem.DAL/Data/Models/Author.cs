using System.ComponentModel.DataAnnotations;

namespace NewsSystem.DAL;

public class Author
{
    public int Id { get; set; }
    [Required]
   // [StringLength(20, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    public ICollection<News> News { get; set; } = new HashSet<News>();
}
