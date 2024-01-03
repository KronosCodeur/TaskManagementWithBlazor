using Task = TaskManagement.Shared.Models.Task;

namespace TaskManagement.Server.Repositories;

public interface TasksRepository
{
    Task<List<Task>> GetAllTasks();
    Task<Task?> GetTaskDetails(int id);
    Task<bool> UpdateTask(int id,Task task);
    Task<bool> CreateTask(Task task);
}