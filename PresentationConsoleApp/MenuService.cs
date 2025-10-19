using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Services;

namespace PresentationConsoleApp;


public class MenuService
{
    private readonly IProductService _productManager;


    public MenuService(IProductService productManager)
    {
        _productManager = productManager;
    }

    public void AddMenuOption()
    {
        var product = new Product();

        Console.Write("Product Name.	");
        var name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Product Name is required. Please enter a valid name: ");
            Console.Write("Product Name.	");
            name = Console.ReadLine();
        }

        product.Name = name;

        Console.Write("Product Price.	");
        var priceInput = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(priceInput) || !decimal.TryParse(priceInput, out var price))
        {
            Console.WriteLine("Product price is required and must be a valid number. Please enter a valid price: ");
            Console.Write("Product price.	");
            priceInput = Console.ReadLine();
        }

        product.Price = decimal.Parse(priceInput);

        var result = _productManager.AddProductToList(product);
        if (result != null && result.Success)
            Console.WriteLine("Product added successfully.");
        else
            Console.WriteLine("Failed to add product.");
        Console.ReadKey();
    }

    private void ViewMenuOption(ProductResult<IEnumerable<Product>> productResult)
    {
        var products = productResult.Content;
        if (products != null)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}");
            }
        }
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    private void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    AddMenuOption();
                    break;
                case "2":
                    Console.Clear();
                    var productResult = _productManager.GetAllProducts();
                    ViewMenuOption(productResult);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    public void Run()
    {
        //_productManager.GetAllProducts();
        MainMenu();
    }
}
