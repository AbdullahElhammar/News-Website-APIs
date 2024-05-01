

using NewsSystem.DAL;

namespace NewsSystem.BL;

public interface IAuthorManager
{
    IEnumerable<AuthorRead_Add_UpdateDto> GetAll();
    AuthorRead_Add_UpdateDto? GetById(int id);
    int Add(AuthorRead_Add_UpdateDto author);
    bool Update(AuthorRead_Add_UpdateDto author);
    bool Delete(int id);
    AuthorReadDetailsDto? GetAuthorWithDetails(int id);
}
