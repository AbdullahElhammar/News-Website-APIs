using NewsSystem.DAL;

namespace NewsSystem.BL;

public class NewsManager:INewsManager
{
    private readonly INewsRepo repo;
    public NewsManager(INewsRepo repo)
    {
            this.repo= repo;
    }
    public IEnumerable<NewsReadDto> GetAll()
    {
        IEnumerable<News> news = repo.GetAll();
        return news.Select(news => new NewsReadDto
        {
            Id= news.Id,
            Title=news.Title,
            Images=news.Images.Select(I=> new ImageChildDto
            {
                Id = I.Id,
                ImgUrl=I.ImgUrl
            }).ToList()
        });
    }

    public NewsReadDto? GetById(int id)
    {
        News? news = repo.GetById(id);
        if (news is null)
        {
            return null;
        }
        return new NewsReadDto
        {
            Id= news.Id,
            Title = news.Title,
            Images = news.Images.Select(I => new ImageChildDto 
            {
                Id=I.Id,
                ImgUrl= I.ImgUrl
            }).ToList()
        };
    }

    public NewsReadDetailsDto? GetNewsWithDetails(int id)
    {
        News? news = repo.GetById(id);
        if (news is null)
        {
            return null;
        }
        return new NewsReadDetailsDto
        {
            Id = news.Id,
            Title = news.Title,
            Description=news.Description,
            Images = news.Images.Select(I => new ImageChildDto
            {
                Id = I.Id,
                ImgUrl = I.ImgUrl
            }).ToList()
        };
    }

    public int Add(NewsAddDto news)
    {
        News? NewsToAdd = new News();
        NewsToAdd.Id= news.Id;
        NewsToAdd.Title= news.Title;
        NewsToAdd.Description=news.Description;
        NewsToAdd.Images=news.Images.Select(I => new Image
        {
            ImgUrl=I.ImgUrl
        }).ToList();
        repo.Add(NewsToAdd);
        repo.SaveChanges();
        return news.Id;
       
    }

    public bool Delete(int id)
    {
        News? NewsToDelete= repo.GetById(id);
        if (NewsToDelete is null)
        {
            return false;
        }
        repo.Delete(NewsToDelete);
        repo.SaveChanges();
        return true;
    }


    public bool Update(NewsUpdateDto news)
    {
        News? NewsToUpdate = repo.GetById(news.Id);
        if (NewsToUpdate is null)
        {
            return false;
        }
        NewsToUpdate.Title= news.Title;
        NewsToUpdate.Description=news.Description;
        repo.SaveChanges();
        return true;    
    }
}
