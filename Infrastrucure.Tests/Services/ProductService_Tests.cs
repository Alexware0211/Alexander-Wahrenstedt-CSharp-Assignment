
using Infrastructure.Services;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Moq;

namespace Infrastrucure.Tests.Services;

public class ProductService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly ProductService _productService;

    public ProductService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _productService = new ProductService(_fileServiceMock.Object, @"c:\");
    }

    [Fact]
    public void AddProductToList_ShouldReturnTrue_WhenProductAddedToList()
    {
        //Arrange
        _fileServiceMock.Setup(fs => fs
            .SaveContentToFile(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(new FileResult { Success = true });

        //Act
        var result = _productService.AddProductToList(new Product { Name = "Test", Price = 10 });

        //Assert
        Assert.True(result.Success);
    }
}
