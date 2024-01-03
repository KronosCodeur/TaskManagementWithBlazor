using Microsoft.EntityFrameworkCore;
using Task = TaskManagement.Shared.Models.Task;

namespace TaskManagement.Server.Data;

public class ApiDbContext :DbContext
{
    public ApiDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Task> Tasks { get; set; }
}