namespace KindLink.Models;

public class VolunteerPosition
{
    public int VolunteerPositionId { get; set; } // Primary Key
    
    //Atributes
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime EventDate { get; set; }

    public string Location { get; set; }
    
    public int OrganizationId { get; set; } // Foreign Key
    public Organization? Organization { get; set; }
    
    public string? Image { get; set; }

}