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
        var organizations = _context.Organization.ToList();
        return View(organizations);
    }
    // Create
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create([Bind("Name,Email,PhoneNumber,Address")] Organization organization)
    {
        // Validating the inputs
        if (!ModelState.IsValid)
        {
            //Refresh
            return View();
        }

        // Creating the new organization
        _context.Organization.Add(organization);
        //Saving
        _context.SaveChanges();

        // Go back to the index
        return RedirectToAction("Index");
    }
    
    // Edit
    public IActionResult Edit()
    {
        return View();
    }
    
}