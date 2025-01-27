﻿

namespace NewsSystem.BL;

public class NewsChildDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<ImageChildDto> Images { get; set; } = new HashSet<ImageChildDto>();
}
