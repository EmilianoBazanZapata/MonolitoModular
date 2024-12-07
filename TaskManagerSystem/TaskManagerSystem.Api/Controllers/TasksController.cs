using Microsoft.AspNetCore.Mvc;
using TaskManagerSystem.Api.Helpers;
using TaskManagerSystem.Application.DTOs;
using TaskManagerSystem.Application.Services;

namespace TaskManagerSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController(TaskService taskService) : ControllerBase
    {
        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await taskService.GetAllTasksAsync();
            return SuccessResponseHelper.CreateResponse(tasks, "Tasks retrieved successfully.");
        }

        // GET: api/tasks/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await taskService.GetTaskByIdAsync(id);
            return SuccessResponseHelper.CreateResponse(task, $"Task with ID {id} retrieved successfully.");
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskDto taskDto)
        {
            var task = await taskService.AddTaskAsync(taskDto);
            return SuccessResponseHelper.CreateResponse(task, "Task created successfully.");
        }

        // PUT: api/tasks
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TaskDto taskDto)
        {
            await taskService.UpdateTaskAsync(taskDto);
            return SuccessResponseHelper.CreateResponse<object>(null, "Task updated successfully.");
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await taskService.DeleteTaskAsync(id);
            return SuccessResponseHelper.CreateResponse<object>(null, "Task deleted successfully.");
        }
    }
}