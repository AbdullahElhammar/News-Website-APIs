

using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace NewsSystem.BL;

public class FormAddNewsData
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<IFormFile> Images { get; set; } = new();
}
