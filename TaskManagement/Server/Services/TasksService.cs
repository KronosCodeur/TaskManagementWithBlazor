using Microsoft.EntityFrameworkCore;
using TaskManagement.Server.Data;
using TaskManagement.Server.Repositories;
using Task = TaskManagement.Shared.Models.Task;

namespace TaskManagement.Server.Services;

public class TasksService : TasksRepository
{
    private readonly ApiDbContext _apiDbContext;

    public TasksService(ApiDbContext apiDbContext)
    {
        _apiDbContext = apiDbContext;
    }
    public async Task<List<Task>> GetAllTasks()
    {
        var tasks = await _apiDbContext.Tasks.ToListAsync();
        return tasks;
    }

    public async Task<Task?> GetTaskDetails(int id)
    {
        var task = await _apiDbContext.Tasks.FirstOrDefaultAsync(task => task.Id == id);
        return task;
    }

    public async Task<bool> UpdateTask(int id,Task task1)
    {
        var taskExist = await _apiDbContext.Tasks.FirstOrDefaultAsync(task => task.Id == id);
        if (taskExist is null)
        {
            return false;
        }
        taskExist.Title = task1.Title;
        taskExist.Description = task1.Description;
        taskExist.Done = task1.Done;
        await _apiDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CreateTask(Task task)
    {
        try
        {
            task.Done = false;
            await _apiDbContext.Tasks.AddAsync(task);
            await _apiDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}