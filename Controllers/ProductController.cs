using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleStore.Areas.Identity.Data;
using StyleStore.Models;

namespace StyleStore.Controllers;

public class ProductController : Controller
{
    private readonly StyleStoreIdentityDbContext _context;

    public ProductController(StyleStoreIdentityDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? categoryId)
    {
        var products = _context.Products
            .Include(p => p.Category)
            .Where(p => p.IsActive && p.Category.IsActive);

        if (categoryId.HasValue)
        {
            products = products.Where(p => p.CategoryId == categoryId.Value);
        }

        return View(await products.ToListAsync());
    }
}