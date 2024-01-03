using System.Net;
using System.Net.Http.Json;
using TaskManagement.Client.Repositories;
using Task = TaskManagement.Shared.Models.Task;
namespace TaskManagement.Client.Services;


public class TasksService : TasksRepository
{
    private readonly HttpClient _httpClient;

    public TasksService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Task>?> GetAllTasks()
    {
        return await _httpClient.GetFromJsonAsync<List<Task>>("api/Tasks");
    }

    public async Task<Task?> GetTaskDetails(int id)
    {
        return await _httpClient.GetFromJsonAsync<Task?>($"api/Tasks/{id}");
    }

    public async Task<bool> UpdateTask(int id, Task task)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Tasks/{id}",task);
        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return true;
        }
        return false;
    }

    public async Task<bool> CreateTask(Task task)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Tasks", task);
        if (response.StatusCode==HttpStatusCode.Created)
        {
            return true;
        }
        return false;
    }
}