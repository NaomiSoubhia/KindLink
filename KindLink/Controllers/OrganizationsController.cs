using KindLink.Data;
using KindLink.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KindLink.Controllers;
public class OrganizationsController : Controller
{
    
    // DB connection
    private readonly ApplicationDbContext _context;

    // Constructor with database context
    public OrganizationsController(ApplicationDbContext context)
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
    [Authorize] // just logged users can access it
    public IActionResult Create()
    {
        return View("Create");
    }
    
    [Authorize] // just logged users can access it
    [HttpPost]
    public IActionResult Create([Bind("Name,Email,PhoneNumber,Address,Image")] Organization organization)
    {
        // Validating the inputs
        if (!ModelState.IsValid)
        {
            //Refresh
            return View("Create");
        }

        // Creating the new organization
        _context.Organization.Add(organization);
        //Saving
        _context.SaveChanges();

        // Go back to the index
        return RedirectToAction("Index");
    }
    
    // GET
    [Authorize] // just logged users can access
    public IActionResult Edit(int id)
    {
        // fetch category by id
        var organization = _context.Organization.Find(id);

        if (organization == null)
        {
            return NotFound();
        }

        // Send all the infos to the view
        return View("Edit", organization);    
    }

    // POST
    [Authorize] // just logged users can access
    [HttpPost]
    public IActionResult Edit([Bind("OrganizationId,Name,Email,PhoneNumber,Address,Image")] Organization organization)
    {
        // Validate
        if (!ModelState.IsValid)
        {
            return View("Edit", organization);
        }

        // Update in the database
        _context.Organization.Update(organization);
        _context.SaveChanges();

        // Return to Index
        return RedirectToAction("Index");
    }

    // GET
    [Authorize] // just logged users can access
    public IActionResult Delete(int id)
    {
        // Search for the organozation ID
        var organization = _context.Organization.Find(id);

        if (organization == null)
        {
            // Not Found
            return NotFound();
        }
        
        // Check if childs
        if (organization.VolunteerPosition == null)
        {
            return View("Error");
        }

        // Delete
        _context.Organization.Remove(organization);
        //Save
        _context.SaveChanges();

        // Back to index
        return RedirectToAction("Index");
    }
}