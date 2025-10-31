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
    [Key] public Guid ClientId { get; set; } = Guid.NewGuid();

    [Required] public string LastName { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public DateTime BirthDate { get; set; }

    [Required] [Phone] public string PhoneNumber { get; set; }

    [Required] public string Email { get; set; }
}