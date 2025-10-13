using Infrastructure.Models;
namespace Infrastructure.Interfaces;

public interface IProductResult
{
    ProductResult AddProductToList(Product product);

    ProductResult<IEnumerable<Product>> GetAllProducts();
}
