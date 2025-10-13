namespace Infrastructure.Models;

public class ProductResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}

public class ProductResult<T> : ProductResult
{
    public T? Content { get; set; }
}