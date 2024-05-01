


using Microsoft.EntityFrameworkCore;

namespace NewsSystem.DAL;

public class NewsRepo : INewsRepo
{
    private readonly SystemContext context;
    public NewsRepo(SystemContext context)
    {
            this.context = context;
    }

    public IEnumerable<News> GetAll()
    {
        return context.News.Include(n => n.Images);
    }

    public News? GetById(int id)
    {
        return context.Set<News>().FirstOrDefault(n => n.Id == id);
    }
    public News? GetAuthorWithDetails(int id)
    {
        return context.Set<News>().Include(n=>n.Author).FirstOrDefault(n => n.Id == id);
    }
    public void Add(News news)
    {
        context.Set<News>().Add(news);  
    }

    public void Delete(News news)
    {
        context.Set<News>().Remove(news);
    }
    public void Update(News news)
    {
        //.....
    }
    public int SaveChanges()
    {
        return context.SaveChanges();
    }

 
}
