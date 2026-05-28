using KindLink.Data;
using KindLink.Models;
using Microsoft.AspNetCore.Mvc;

namespace KindLink.Controllers;

public class OrganizationController : Controller
{
    
    // DB connection
    private readonly ApplicationDbContext _context;

    // Constructor with database context
    public OrganizationController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // GET
    public IActionResult Index()
    {
        var organizations = new List<Organization>();
        return View(organizations);
    }
    // Create
    public IActionResult Create()
    {
        return View();
    }
    
    // Edit
    public IActionResult Edit()
    {
        return View();
    }
    
}