using KindLink.Models;
using Microsoft.AspNetCore.Mvc;

namespace KindLink.Controllers;

public class VolunteerPositionController : Controller
{
    // GET
    public IActionResult Index()
    {
        var volunteerPositions = new List<VolunteerPosition>();
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