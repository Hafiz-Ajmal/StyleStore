using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleStore.Areas.Identity.Data;
using StyleStore.ViewModels;

namespace StyleStore.Controllers;

public class AdminController : Controller
{
    private readonly StyleStoreIdentityDbContext _context;

    public AdminController(StyleStoreIdentityDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var dashboard = new AdminDashboardViewModel
        {
            TotalProducts = await _context.Products.CountAsync(),

            TotalCategories = await _context.Categories.CountAsync(),

            TotalUsers = await _context.Users.CountAsync()
        };

        return View(dashboard);
    }
}