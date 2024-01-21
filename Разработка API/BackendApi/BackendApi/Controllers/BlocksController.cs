using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class BlocksController : ControllerBase
    {
        public dbapiContext Context { get; }

        public BlocksController(dbapiContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Block> blocks = Context.Blocks.ToList();
            return Ok(blocks);
        }

        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Block blocks = Context.Blocks.Where(x => x.BlockId == id).FirstOrDefault();
            if (blocks == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(blocks);
        }

        [HttpPost]

        public IActionResult Add(Block blocks) //добавление записей 
        {
            Context.Blocks.Add(blocks);
            Context.SaveChanges();
            return Ok(blocks);
        }

        [HttpPut]
        public IActionResult Update(Block blocks) //Обновление данных (Изменение существующей записи)
        {
            Context.Blocks.Update(blocks);
            Context.SaveChanges();
            return Ok(blocks);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Block? blocks = Context.Blocks.Where(x => x.BlockId == id).FirstOrDefault();
            if (blocks == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Blocks.Remove(blocks);
            Context.SaveChanges();
            return Ok(blocks);
        }
    }
}
 
