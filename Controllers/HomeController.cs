using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;
using WebApplication9.Context;
using WebApplication9.Models;
using WebApplication9.Repositories;

namespace WebApplication9.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    private readonly IProductRepository _productRepository;

    public HomeController(AppDbContext context, IProductRepository productRepository)
    {
        _context = context;
        _productRepository = productRepository;
    }

    public async Task<IActionResult> Index()
    {   
        MyLog log = await _context.Set<MyLog>().FirstOrDefaultAsync();

        IList<Product> products = await _context.Set<Product>().ToListAsync();
        return View(products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(string name)
    {
        Product product = new()
        {
            Name = name,
        };        

        await _productRepository.AddAsync(product, false);
        await _productRepository.SaveChanges();

        return RedirectToAction("Index");        
    }

    [HttpGet]
    public async Task<IActionResult> RemoveProductById(int id)
    {
        await _productRepository.RemoeById(id);
        await _productRepository.SaveChanges();

        return RedirectToAction("Index");
    }

}