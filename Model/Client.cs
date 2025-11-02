namespace AutoRapido.Model;

using System.ComponentModel.DataAnnotations;

/*
- UUID
- LastName
- FirstName
- BirthDate
- PhoneNumber
- Email
- CarList

 */
public class Client
{
    [Key] public Guid ClientId { get; set; } = Guid.NewGuid(); // Generate new ID // TODO Implement generation in database

    [Required] public string LastName { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public DateTime BirthDate { get; set; }

    [Required] [Phone] public string PhoneNumber { get; set; } // Type [Phone] allow format verification. 

    [Required] public string Email { get; set; }
}