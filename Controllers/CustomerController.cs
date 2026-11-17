using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  StyleStore.Areas.Identity.Data;
using StyleStore.Models;

namespace StyleStore.Controllers;

public class CustomerController : Controller
{
    private readonly StyleStoreIdentityDbContext _context; //=StyleStoreIdentityDbContext(); //does not have paramtereless ctor

    public CustomerController(StyleStoreIdentityDbContext contxt)
    {
        _context=contxt;
    }
    public async Task<IActionResult> Index()
    {
        var cat= await _context.Categories.Where(c=>c.IsActive==true).ToListAsync();
        return View(cat);
    }
}