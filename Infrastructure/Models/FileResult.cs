
namespace Infrastructure.Models;

public class FileResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Content { get; set; }
}
