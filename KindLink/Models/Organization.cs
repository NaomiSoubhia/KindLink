namespace KindLink.Models;

public class Organization
{
    public int OrganizationId { get; set; } // Primary Key
    //Atributes
    
    public string Name { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }
    
    public string? Image { get; set; }
    
    // Child reference to VolunteerPosition: one organization can have many volunteer positions
    public List<VolunteerPosition>? VolunteerPosition { get; set; }

}