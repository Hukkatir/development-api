using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        public dbapiContext Context { get; }

        public CommentsController(dbapiContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Comment> comments = Context.Comments.ToList();
            return Ok(comments);
        }

        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Comment comments = Context.Comments.Where(x => x.CommentId == id).FirstOrDefault();
            if (comments == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(comments);
        }

        [HttpPost]

        public IActionResult Add(Comment comments) //добавление записей 
        {
            Context.Comments.Add(comments);
            Context.SaveChanges();
            return Ok(comments);
        }

        [HttpPut]
        public IActionResult Update(Comment comments) //Обновление данных (Изменение существующей записи)
        {
            Context.Comments.Update(comments);
            Context.SaveChanges();
            return Ok(comments);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Comment? comments = Context.Comments.Where(x => x.CommentId == id).FirstOrDefault();
            if (comments == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Comments.Remove(comments);
            Context.SaveChanges();
            return Ok(comments);
        }
    }
}
