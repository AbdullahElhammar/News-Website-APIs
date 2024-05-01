namespace NewsSystem.DAL;

public interface INewsRepo
{
    IEnumerable<News> GetAll();
    News? GetById(int id);
    News? GetAuthorWithDetails(int id);
    void Add(News news);
    void Update(News news);
    void Delete(News news);
    int SaveChanges();
}
