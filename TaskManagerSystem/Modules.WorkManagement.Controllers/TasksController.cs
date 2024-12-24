
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modules.WorkManagement.Application.Features.Tasks.Commands.AssignTask;
using Modules.WorkManagement.Application.Features.Tasks.Commands.CreateTask;
using Modules.WorkManagement.Application.Features.Tasks.Commands.DeleteTask;
using Modules.WorkManagement.Application.Features.Tasks.Commands.UpdateTask;
using Modules.WorkManagement.Application.Features.Tasks.Queries.GetAllTasksQuery;
using Modules.WorkManagement.Application.Features.Tasks.Queries.GetTaskByIdQuery;
using TaskManager.Shared.Core.Helpers;

namespace Modules.WorkManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TasksController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _mediator.Send(new GetAllTasksQuery());
            return SuccessResponseHelper.CreateResponse(tasks, "Tasks retrieved successfully.");
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _mediator.Send(new GetTaskByIdQuery(id));
            return SuccessResponseHelper.CreateResponse(task, $"Task with ID {id} retrieved successfully.");
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
        {
            var taskId = await _mediator.Send(command);
            return SuccessResponseHelper.CreateResponse(taskId,"Task created successfully.");
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTaskCommand command)
        {
            await _mediator.Send(command);
            return SuccessResponseHelper.CreateResponse("Task updated successfully.");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTaskCommand(id));
            return SuccessResponseHelper.CreateResponse("Task deleted successfully.");
        }
        
        [HttpPost("assign")]
        public async Task<IActionResult> AssignTaskToUser([FromBody] AssignTaskCommand command)
        {
            await _mediator.Send(command);
            return SuccessResponseHelper.CreateResponse( "Task assigned successfully.");
        }
    }
}