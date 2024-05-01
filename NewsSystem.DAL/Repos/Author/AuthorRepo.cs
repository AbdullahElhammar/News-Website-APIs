


using Microsoft.EntityFrameworkCore;

namespace NewsSystem.DAL;

public class AuthorRepo : IAuthorRepo
{
    private readonly SystemContext context;
    public AuthorRepo(SystemContext context) 
    {
        this.context = context;
    }
    public IEnumerable<Author> GetAll()
    {
       return context.Set<Author>();
    }
    public Author? GetById(int id)
    {
        return context.Set<Author>().FirstOrDefault(a => a.Id == id);
    }
    public Author? GetAuthorWithDetails(int id)
    {
        return context.Set<Author>().Include(a=>a.News).ThenInclude(n=>n.Images).FirstOrDefault(a => a.Id == id);
    }
    public void Add(Author author)
    {
        context.Set<Author>().Add(author);
    }

    public void Delete(Author book)
    {
        context.Set<Author>().Remove(book); 
    }

    public void Update(Author book)
    {
       //....
    }
    public int SaveChanges()
    {
        return context.SaveChanges();
    }
}

