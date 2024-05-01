

namespace NewsSystem.DAL;

public interface IAuthorRepo
{
    IEnumerable<Author> GetAll();
    Author? GetById(int id);
    void Add(Author author);
    void Update(Author author);
    void Delete(Author author);
    Author? GetAuthorWithDetails(int id);
    int SaveChanges();
}
