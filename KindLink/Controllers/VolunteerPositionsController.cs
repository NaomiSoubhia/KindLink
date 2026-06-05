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
    
    //Post: Create
    [HttpPost]
    public IActionResult Create([Bind("Title, Description, EventDate,Location,OrganizationId")] VolunteerPosition volunteerPosition)
    {
            
        // validate
        if (!ModelState.IsValid)
        {
            return View(volunteerPosition);
        }

        // Create
        _context.VolunteerPosition.Add(volunteerPosition);
        // Save in the database
        _context.SaveChanges();

        // Index
        return RedirectToAction("Index");
    }
    // GET edit
    public IActionResult Edit(int id)
    {
        // find volunteer by id
        var volunteerPosition = _context.VolunteerPosition.Find(id);

        // return NotFound() if not found volunteerPosition
        if (volunteerPosition == null)
        {
            return NotFound();
        }

        // Dropdown
        ViewBag.OrganizationId = new SelectList(_context.Organization.OrderBy(c => c.Name).ToList(), "OrganizationId", "Name");

        // pass product data to view for display
        return View(volunteerPosition);
    }

    // POST
    [HttpPost]
    public IActionResult Edit([Bind("VolunteerPositionId,Title, Description, EventDate,Location,OrganizationId")] VolunteerPosition volunteerPosition)
    {
        // Validate
        if (!ModelState.IsValid)
        {
            return View();
        }

        // Update in the database
        _context.VolunteerPosition.Update(volunteerPosition);
        _context.SaveChanges();

        // Return to Index
        return RedirectToAction("Index");
    }
    
    // GET: Delete
    public IActionResult Delete(int id)
    {
        // Find Volunteer Position by id
        var volunteerPosition = _context.VolunteerPosition.Find(id);

        //  Return NotFound() if not found volunteerPosition
        if (volunteerPosition == null)
        {
            return NotFound();
        }

        // Remove from database and save
        _context.VolunteerPosition.Remove(volunteerPosition);
        _context.SaveChanges();

        // Refresh page
        return RedirectToAction("Index");
    }
    
}