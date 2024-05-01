

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsSystem.DAL;

public class Image
{
    public int Id { get; set; }
    [Required]
    public string ImgUrl { get; set; } = string.Empty;
    [ForeignKey("News")]
    public int? NewsId { get; set; }
    public News? News { get; set; }
}
