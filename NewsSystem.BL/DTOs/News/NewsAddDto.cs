namespace NewsSystem.BL;

public class NewsAddDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<ImageForAddNewsDto> Images { get; set; } = new HashSet<ImageForAddNewsDto>();
}

//forgot fk of authorId