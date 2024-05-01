
namespace NewsSystem.BL;

public class NewsReadDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public ICollection<ImageChildDto> Images { get; set; } = new HashSet<ImageChildDto>();
}
