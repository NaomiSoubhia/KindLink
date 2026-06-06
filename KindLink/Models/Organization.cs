using System.ComponentModel.DataAnnotations;

namespace KindLink.Models;

public class Organization
{
    //Atributes
    public int OrganizationId { get; set; } // Primary Key
    
    public string Name { get; set; }

    // EmailAddressAttribute Class: https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.emailaddressattribute?view=net-10.0&redirectedfrom=MSDN
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; }

    // Import DataAnnotations: Learned in: https://www.twilio.com/en-us/blog/validating-phone-numbers-effectively-with-c-and-the-net-frameworks#:~:text=Component.-,DataAnnotations,field%20is%20an%20object%20type.
    //Just allow formatting characters such as parentheses, dashes and numbers
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string PhoneNumber { get; set; }

    public string Address { get; set; }
    

    
    // Child reference to VolunteerPosition: one organization can have many volunteer positions
    public List<VolunteerPosition>? VolunteerPosition { get; set; }

}