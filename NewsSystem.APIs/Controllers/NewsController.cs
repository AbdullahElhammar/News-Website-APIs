using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsSystem.BL;

namespace NewsSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsManager manager;

        public NewsController(INewsManager manager)
        {
            this.manager = manager;
        }
        [HttpGet]
        [Route("GetAllNews")]
        public ActionResult<List<NewsReadDto>> GetAll()
        {
            return manager.GetAll().ToList();
        }

        [Authorize]
        [HttpGet]
        [Route("GetNewsById/{id}")]
        public ActionResult<NewsReadDto> GetById(int id)
        {
            NewsReadDto? News = manager.GetById(id);
            if (News is null)
            {
                return NotFound();
            }
            return News;
        }

        [Authorize]
        [HttpGet]
        [Route("GetNewsWithDetails/{id}")]
        public ActionResult<NewsReadDetailsDto> GetNewsWithDetails(int id)
        {
            NewsReadDetailsDto? BookWithDetails = manager.GetNewsWithDetails(id);
            if (BookWithDetails is null)
            {
                return NotFound();
            }
            return BookWithDetails;
        }

       // [Authorize]
        [HttpPost]
        [Route("AddNews")]
        public async Task<ActionResult> Add([FromForm]FormAddNewsData AddRequest)
        {
            NewsAddDto? NewsToAdd = new NewsAddDto()
            {
                Id= AddRequest.Id,
                Title= AddRequest.Title,
                Description= AddRequest.Description,
            };
            var AllowedExtensions = new string[] { ".png", ".jpg", ".svg",".jpeg" };
            var MaxFileSize = 4_000_000; // 4 MB
            for (int i = 0; i < AddRequest.Images.Count; i++)
            {
                // Check extension
                var extension = Path.GetExtension(AddRequest.Images[i].FileName);
                if (!AllowedExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase))
                {
                    return BadRequest("Extension is not valid");
                }

                // Check file size
                if (AddRequest.Images[i].Length > MaxFileSize)
                {
                    return BadRequest("File size exceeds the maximum allowed size of 4 MB");
                }

                // Generate unique file name
                var newFileName = $"{NewsToAdd?.Title}{i + 1}{extension}";

                // Save the file
                using (var stream = new FileStream($"Assets/Images/{newFileName}", FileMode.Create))
                {
                    await AddRequest.Images[i].CopyToAsync(stream);
                }

                ImageForAddNewsDto img = new ImageForAddNewsDto
                {
                    ImgUrl = newFileName,
                };
                NewsToAdd?.Images.Add(img);
            }
            manager.Add(NewsToAdd);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateNews")]
        public ActionResult Update(NewsUpdateDto news)
        {
            var IsFound = manager.Update(news);
            if (!IsFound)
            {
                return NotFound();
            }
            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteNews")]

        public ActionResult Delete(int id)
        {
            var IsFound = manager.Delete(id);
            if (!IsFound) { return NotFound(); }
            return Ok("News Deleted Successfully");
        }
    }
}
