using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextTypeController : ControllerBase
    {
        public dbapiContext Context { get; }

        public TextTypeController(dbapiContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<TextType> textTypes = Context.TextTypes.ToList();
            return Ok(textTypes);
        }

        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            TextType textTypes = Context.TextTypes.Where(x => x.TextTypeId == id).FirstOrDefault();
            if (textTypes == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(textTypes);
        }

        [HttpPost]

        public IActionResult Add(TextType textTypes) //добавление записей 
        {
            Context.TextTypes.Add(textTypes);
            Context.SaveChanges();
            return Ok(textTypes);
        }

        [HttpPut]
        public IActionResult Update(TextType textTypes) //Обновление данных (Изменение существующей записи)
        {
            Context.TextTypes.Update(textTypes);
            Context.SaveChanges();
            return Ok(textTypes);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            TextType? textTypes = Context.TextTypes.Where(x => x.TextTypeId == id).FirstOrDefault();
            if (textTypes == null)
            {
                return BadRequest("Не найдено");

            }
            Context.TextTypes.Remove(textTypes);
            Context.SaveChanges();
            return Ok(textTypes);
        }
    }
}
