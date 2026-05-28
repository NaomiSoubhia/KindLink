using KindLink.Data;
using KindLink.Models;
using Microsoft.AspNetCore.Mvc;

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
        return View();
    }
    
    // Edit
    public IActionResult Edit()
    {
        return View();
    }
    
}