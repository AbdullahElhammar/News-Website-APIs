using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsSystem.BL;

namespace NewsSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorManager manager;

        public AuthorController(IAuthorManager manager)
        {
            this.manager = manager;
        }
        [HttpGet]
        [Route("GetAllAuthors")]
        public ActionResult<List<AuthorRead_Add_UpdateDto>> GetAll()
        {
            return manager.GetAll().ToList();
        }
        [HttpGet]
        [Route("GetAuthorById/{id}")]
        public ActionResult<AuthorRead_Add_UpdateDto> GetById(int id)
        {
            AuthorRead_Add_UpdateDto? author = manager.GetById(id);
            if (author is null)
            {
                return NotFound();
            }
            return Ok(author);
        }
        [HttpPost]
        [Route("AddAuthor")]
        public ActionResult Add(AuthorRead_Add_UpdateDto author)
        {
            manager.Add(author);
            return Ok("author added successfully");
        }

        [HttpPut]
        [Route("UpdateAuthor")]
        public ActionResult Update(AuthorRead_Add_UpdateDto author)
        {
            var IsFound = manager.Update(author);
            if (!IsFound)
            {
                return NotFound();
            }
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [Route("DeleteAuthor")]
        public ActionResult Delete(int id)
        {
            var IsFound = manager.Delete(id);
            if (!IsFound) { return NotFound(); }
            return Ok("Deleted Successfully");
        }
    }
}
