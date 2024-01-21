using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public dbapiContext Context { get; }

        public ImagesController(dbapiContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Image> images = Context.Images.ToList();
            return Ok(images);
        }

        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Image images = Context.Images.Where(x => x.ImageId == id).FirstOrDefault();
            if (images == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(images);
        }

        [HttpPost]

        public IActionResult Add(Image images) //добавление записей 
        {
            Context.Images.Add(images);
            Context.SaveChanges();
            return Ok(images);
        }

        [HttpPut]
        public IActionResult Update(Image images) //Обновление данных (Изменение существующей записи)
        {
            Context.Images.Update(images);
            Context.SaveChanges();
            return Ok(images);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Image? images = Context.Images.Where(x => x.ImageId == id).FirstOrDefault();
            if (images == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Images.Remove(images);
            Context.SaveChanges();
            return Ok(images);
        }
    }
}
