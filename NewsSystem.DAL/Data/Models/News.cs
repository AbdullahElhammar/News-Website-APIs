namespace NewsSystem.DAL;

public class News
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; }= string.Empty;
    public ICollection<Image> Images { get; set; } = new HashSet<Image>();
    public Author? Author { get; set; }
}

