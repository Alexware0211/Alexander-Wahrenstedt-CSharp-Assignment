using Infrastructure.Interfaces;
using Infrastructure.Models;
using Newtonsoft.Json;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly string _path;
    private readonly  IFileService _fileService;
    private List<Product> _productList;

    public ProductService(IFileService fileRepository, string filePath)
    {
        _path = filePath;
        _fileService = fileRepository;
        _productList = [];
    }

    public ProductResult AddProductToList(Product product)
    {
        try
        {
            _productList.Add(product);
            var json = JsonConvert.SerializeObject(_productList);

            var result = _fileService.SaveContentToFile(_path, json);

            if (result.Success)
                return new ProductResult { Success = true };

            return new ProductResult { Success = false, ErrorMessage = result.ErrorMessage };
        }
        catch (Exception ex)
        {
            return new ProductResult { Success = false, ErrorMessage = ex.Message };
        }
    }

    public ProductResult<IEnumerable<Product>> GetAllProducts()
    {
        return _productList.Count > 0
            ? new ProductResult<IEnumerable<Product>> { Success = true, Content = _productList }
            : new ProductResult<IEnumerable<Product>> { Success = false, ErrorMessage = "No products found." };
    }
}
