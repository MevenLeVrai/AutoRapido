namespace AutoRapido.Model;
using System.ComponentModel.DataAnnotations;

/*
    - UUID 
    - Nom
    - Liste voiture
    - Liste Client
    */

public class Concession
{
    [Key]
    public Guid ConcessionId { get; set; } = Guid.NewGuid(); // Generate new ID // TODO Implement generation in database

    [Required]
    public string Name { get; set; }

    public ICollection<Car> ListCars { get; set; } = new List<Car>();
    public ICollection<Client> ListClients { get; set; } = new List<Client>();
    
    
}
