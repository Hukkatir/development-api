using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        public dbapiContext Context { get; }

        public FeedbackController(dbapiContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Feedback> feedbacks = Context.Feedbacks.ToList();
            return Ok(feedbacks);
        }

        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Feedback feedbacks = Context.Feedbacks.Where(x => x.FeedbackId == id).FirstOrDefault();
            if (feedbacks == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(feedbacks);
        }

        [HttpPost]

        public IActionResult Add(Feedback feedbacks) //добавление записей 
        {
            Context.Feedbacks.Add(feedbacks);
            Context.SaveChanges();
            return Ok(feedbacks);
        }

        [HttpPut]
        public IActionResult Update(Feedback feedbacks) //Обновление данных (Изменение существующей записи)
        {
            Context.Feedbacks.Update(feedbacks);
            Context.SaveChanges();
            return Ok(feedbacks);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Feedback? feedbacks = Context.Feedbacks.Where(x => x.FeedbackId == id).FirstOrDefault();
            if (feedbacks == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Feedbacks.Remove(feedbacks);
            Context.SaveChanges();
            return Ok(feedbacks);
        }
    }
}

