using NewsSystem.DAL;

namespace NewsSystem.BL;

public class AuthorManager:IAuthorManager
{
    private readonly IAuthorRepo repo;
    public AuthorManager(IAuthorRepo repo)
    {
        this.repo = repo;    
    }
    public IEnumerable<AuthorRead_Add_UpdateDto> GetAll()
    {
        var Authors=  repo.GetAll();
        return Authors.Select(author => new AuthorRead_Add_UpdateDto
        {
            Id= author.Id,
            Name= author.Name
        });
    }

    public AuthorRead_Add_UpdateDto? GetById(int id)
    {
        Author? author= repo.GetById(id);   
        if (author==null) return null;
        return new AuthorRead_Add_UpdateDto 
        { Id= author.Id,
          Name= author.Name
        };
    }
    public AuthorReadDetailsDto? GetAuthorWithDetails(int id)
    {
       Author? AuthorWithDetails= repo.GetAuthorWithDetails(id);
        if (AuthorWithDetails is null)
        {
            return null;
        }
        return new AuthorReadDetailsDto
        {
            Id= AuthorWithDetails.Id,
            Name = AuthorWithDetails.Name,
            News=AuthorWithDetails.News.Select(N=> new NewsChildDto
            {
                Id = N.Id,
                Title= N.Title,
                Description= N.Description,
                Images=N.Images.Select(I=>new ImageChildDto { Id=I.Id, ImgUrl=I.ImgUrl}).ToList()
            }).ToList()
        };
    }

    public int Add(AuthorRead_Add_UpdateDto author)
    {
        var AuthorToAdd = new Author
        {
            Id= author.Id,
            Name=author.Name
        };
        repo.Add(AuthorToAdd);
        repo.SaveChanges();
        return AuthorToAdd.Id;
    }

    public bool Delete(int id)
    {
        var AuthorToDelet = repo.GetById(id);
        if (AuthorToDelet is null) {  return false; }
        repo.Delete(AuthorToDelet);
        repo.SaveChanges();
        return true;
    }
    public bool Update(AuthorRead_Add_UpdateDto author)
    {
        Author? AuthorToUpdate = repo.GetById(author.Id);
        if (AuthorToUpdate is null) { return false;}
        AuthorToUpdate.Name = author.Name;
        repo.Update(AuthorToUpdate);
        repo.SaveChanges();
        return true;
    }


   
}
