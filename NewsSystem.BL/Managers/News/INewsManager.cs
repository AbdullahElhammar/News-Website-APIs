using NewsSystem.DAL;

namespace NewsSystem.BL;

public interface INewsManager
{
    IEnumerable<NewsReadDto> GetAll();
    NewsReadDto? GetById(int id);
    NewsReadDetailsDto? GetNewsWithDetails(int id);
    int Add(NewsAddDto news);
    bool Update(NewsUpdateDto news);
    bool Delete(int id);
}
