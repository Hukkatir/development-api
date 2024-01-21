using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        public dbapiContext Context { get; }

        public RoleController(dbapiContext context)
        {
            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Role> roles = Context.Roles.ToList();
            return Ok(roles);
        }

        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Role roles = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (roles == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(roles);
        }

        [HttpPost]

        public IActionResult Add(Role roles) //добавление записей 
        {
            Context.Roles.Add(roles);
            Context.SaveChanges();
            return Ok(roles);
        }

        [HttpPut]
        public IActionResult Update(Role roles) //Обновление данных (Изменение существующей записи)
        {
            Context.Roles.Update(roles);
            Context.SaveChanges();
            return Ok(roles);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Role? roles = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (roles == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Roles.Remove(roles);
            Context.SaveChanges();
            return Ok(roles);
        }
    }
}
