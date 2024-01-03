using Microsoft.AspNetCore.Mvc;
using TaskManagement.Server.Services;
using Task = TaskManagement.Shared.Models.Task;

namespace TaskManagement.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController:ControllerBase
{
    private readonly TasksService _tasksService;

    public TasksController(TasksService tasksService)
    {
        _tasksService = tasksService;
    }

    [HttpGet("GetAllTasks")]
    public async Task<ActionResult<List<Task>>> GetAllTasks()
    {
        return Ok(await _tasksService.GetAllTasks());
    }

    [HttpGet("GetTaskDetails/{id}")]
    public async Task<ActionResult<Task>> GetTaskDetails(int id)
    {
        var task = await _tasksService.GetTaskDetails(id);
        if (task is null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpPost("CreateTask")]
    public async Task<IActionResult> CreateTask(Task task)
    {
        await _tasksService.CreateTask(task);
        return CreatedAtAction(nameof(GetTaskDetails), task, task.Id);
    }

    [HttpPut("UpdateTask/{id}")]
    public async Task<IActionResult> UpdateTask(int id,Task task)
    {
        var result = await _tasksService.UpdateTask(id, task);
        if(result)
        {
            return NoContent();
        }

        return NotFound();
    }
}