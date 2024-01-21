using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        public dbapiContext Context { get; }

        public VideoController(dbapiContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Video> videos = Context.Videos.ToList();
            return Ok(videos);
        }

        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Video videos = Context.Videos.Where(x => x.VideoId == id).FirstOrDefault();
            if (videos == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(videos);
        }

        [HttpPost]

        public IActionResult Add(Video videos) //добавление записей 
        {
            Context.Videos.Add(videos);
            Context.SaveChanges();
            return Ok(videos);
        }

        [HttpPut]
        public IActionResult Update(Video videos) //Обновление данных (Изменение существующей записи)
        {
            Context.Videos.Update(videos);
            Context.SaveChanges();
            return Ok(videos);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Video? videos = Context.Videos.Where(x => x.VideoId == id).FirstOrDefault();
            if (videos == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Videos.Remove(videos);
            Context.SaveChanges();
            return Ok(videos);
        }
    }
}
