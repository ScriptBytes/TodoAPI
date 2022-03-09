using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.DTOs;
using TodoAPI.Managers.Interfaces;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoManager manager;

        public TodosController(ITodoManager todoManager)
        {
            this.manager = todoManager;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var d = await manager.GetAsync(id);

            return Ok(d);
        }

        [HttpGet]
        [Route("incomplete")]
        public async Task<IActionResult> GetIncomplete()
        {
            var d = await manager.GetIncomplete();

            return Ok(d);
        }

        [HttpPost]
        public async Task<ActionResult<TodoDTO>> Post([FromBody] TodoPostDTO todo)
        {
            var inserted = await manager.InsertAsync(todo);

            return CreatedAtAction(nameof(GetById), new { id = inserted.Id }, inserted);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<TodoDTO>> Put(int id, [FromBody] TodoPutDTO todo)
        {
            var entity = await manager.UpdateAsync(id, todo);

            return Ok(entity);
        }
    }
}
