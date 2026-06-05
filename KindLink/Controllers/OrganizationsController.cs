using KindLink.Data;
using KindLink.Models;
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
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create([Bind("Name,Email,PhoneNumber,Address,Image")] Organization organization)
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
    
    // GET
    public IActionResult Edit(int id)
    {
        // fetch category by id
        var organization = _context.Organization.Find(id);

        if (organization == null)
        {
            return NotFound();
        }

        // Send all the infos to the view
        return View(organization);
    }

    // POST
    [HttpPost]
    public IActionResult Edit([Bind("OrganizationId,Name,Email,PhoneNumber,Address, Image")] Organization organization)
    {
        // Validate
        if (!ModelState.IsValid)
        {
            return View();
        }

        // Update in the database
        _context.Organization.Update(organization);
        _context.SaveChanges();

        // Return to Index
        return RedirectToAction("Index");
    }

    // GET
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