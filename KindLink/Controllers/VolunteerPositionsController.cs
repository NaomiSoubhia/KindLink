using KindLink.Data;
using KindLink.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
    {            var volunteerPositions = _context.VolunteerPosition
            .Include(p => p.Organization)
            .OrderBy(p => p.Title)
            .ToList();
        
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
    public IActionResult Edit([Bind("VolunteerPositionId,Title, Description, EventDate,Location,OrganizationId")] VolunteerPosition volunteerPosition, IFormFile? Image, string? CurrentImage)
    {
        // input validation
        if (!ModelState.IsValid)
        {
            // Reload if invalid
            return View(volunteerPosition);
        }

        // Check if image is not null and then upload image
        if (Image != null)
        {
            var fileName = UploadImage(Image);
            volunteerPosition.Image = fileName; 
        }
        else
        {
            //Keep the actual image
            volunteerPosition.Image = CurrentImage;  
        }

        // If image is valid, we save in the database
        _context.VolunteerPosition.Update(volunteerPosition);
        _context.SaveChanges();

        // Refresh
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
    
    //Image Upload
    private static string UploadImage(IFormFile Image)
    {
        // get temp location of uploaded image
        var filePath = Path.GetTempFileName();

        // create unique name to prevent overwriting using Globally Unique Identifier (GUID)
        // e.g. product.jpg => 29387rjlf398dsjf-product.jpg
        var fileName = Guid.NewGuid().ToString() + "-" + Image.FileName;

        // set destination path dynamically so it works locally and in production
        var uploadPath = System.IO.Directory.GetCurrentDirectory() + "//wwwroot//img//" + fileName; 

        // use filestream to copy image from temp folder to img folder
        using (var stream = new FileStream(uploadPath, FileMode.Create))
        {
            Image.CopyTo(stream);
        }

        // return new unique file name for saving to db
        return fileName;
    }
    
}