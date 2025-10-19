using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PresentationConsoleApp;
using System.Text.Json;

string filePath = @"c:\data\products.json";

var builder = Host.CreateApplicationBuilder();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IFileRepository, FileRepository>();
builder.Services.AddSingleton<IProductService>(provider =>
    new ProductService(
        provider.GetRequiredService<IFileService>(),
        filePath
    )
);
builder.Services.AddSingleton<MenuService>();


var app = builder.Build();

var menuService = app.Services.GetRequiredService<MenuService>();
menuService.Run();