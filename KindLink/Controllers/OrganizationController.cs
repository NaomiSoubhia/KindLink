using KindLink.Models;
using Microsoft.AspNetCore.Mvc;

namespace KindLink.Controllers;

public class OrganizationController : Controller
{
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