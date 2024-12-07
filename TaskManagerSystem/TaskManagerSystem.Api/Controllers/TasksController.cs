using Microsoft.AspNetCore.Mvc;
using TaskManagerSystem.Application.DTOs;
using TaskManagerSystem.Application.Services;

namespace TaskManagerSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks); // Mapster maneja el mapeo automáticamente en el servicio
        }

        // GET: api/tasks/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Excepción `KeyNotFoundException` será manejada por el middleware
            var task = await _taskService.GetTaskByIdAsync(id);
            return Ok(task);
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskDto taskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await _taskService.AddTaskAsync(taskDto);

            // CreatedAtAction con el nuevo ID
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        // PUT: api/tasks/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskDto taskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != taskDto.Id)
                return BadRequest(new { Message = "ID in the URL and the body do not match." });

            // Excepción `KeyNotFoundException` será manejada por el middleware
            await _taskService.UpdateTaskAsync(taskDto);

            return NoContent();
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Excepción `KeyNotFoundException` será manejada por el middleware
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }
    }
}
