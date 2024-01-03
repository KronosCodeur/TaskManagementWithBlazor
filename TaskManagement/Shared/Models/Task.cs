using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Shared.Models;

public class Task
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Done { get; set; }
}