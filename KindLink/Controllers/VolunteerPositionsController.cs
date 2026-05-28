using KindLink.Data;
using KindLink.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KindLink.Controllers;

public class VolunteerPositionsController : Controller
{
    
    // database object
    private readonly ApplicationDbContext _context;
    
    // Constructor with database context
    public VolunteerPositionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    
    // GET
    public IActionResult Index()
    {
        var volunteerPositions =_context.VolunteerPosition.ToList();
        return View(volunteerPositions);
    }
    // Create
    public IActionResult Create()
    {
        //Dropdown of Organizations
        ViewBag.OrganizationId = new SelectList(_context.Organization.OrderBy(c => c.Name).ToList(), "OrganizationId", "Name");
        
        return View();
    }
    
    // Edit
    public IActionResult Edit()
    {
        return View();
    }
    
}