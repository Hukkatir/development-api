using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockTypeController : ControllerBase
    {
        public dbapiContext Context { get; }

        public BlockTypeController(dbapiContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<BlockType> blockTypes = Context.BlockTypes.ToList();
            return Ok(blockTypes);
        }

        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            BlockType blockTypes = Context.BlockTypes.Where(x => x.BlockTypeId == id).FirstOrDefault();
            if (blockTypes == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(blockTypes);
        }

        [HttpPost]

        public IActionResult Add(BlockType blockTypes) //добавление записей 
        {
            Context.BlockTypes.Add(blockTypes);
            Context.SaveChanges();
            return Ok(blockTypes);
        }

        [HttpPut]
        public IActionResult Update(BlockType blockTypes) //Обновление данных (Изменение существующей записи)
        {
            Context.BlockTypes.Update(blockTypes);
            Context.SaveChanges();
            return Ok(blockTypes);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            BlockType? blockTypes = Context.BlockTypes.Where(x => x.BlockTypeId == id).FirstOrDefault();
            if (blockTypes == null)
            {
                return BadRequest("Не найдено");

            }
            Context.BlockTypes.Remove(blockTypes);
            Context.SaveChanges();
            return Ok(blockTypes);
        }
    }
}
