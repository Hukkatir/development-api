using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        public dbapiContext Context { get; }

        public CategoryController(dbapiContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Category> categories = Context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Category categories = Context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (categories == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(categories);
        }

        [HttpPost]

        public IActionResult Add(Category categories) //добавление записей 
        {
            Context.Categories.Add(categories);
            Context.SaveChanges();
            return Ok(categories);
        }

        [HttpPut]
        public IActionResult Update(Category categories) //Обновление данных (Изменение существующей записи)
        {
            Context.Categories.Update(categories);
            Context.SaveChanges();
            return Ok(categories);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Category? categories = Context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (categories == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Categories.Remove(categories);
            Context.SaveChanges();
            return Ok(categories);
        }
    }
}
