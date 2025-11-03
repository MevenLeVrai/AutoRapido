namespace AutoRapido.Model;
using System.ComponentModel.DataAnnotations;

public class Purchase
{
    [Key]
    public Guid PurchaseId { get; set; } = Guid.NewGuid(); // Generate new ID // TODO Implement generation in database

    [Required]
    public Guid CarId { get; set; } 
    
    public Car Car { get; set; }
    [Required]
    public Guid ClientId { get; set; }  
    
    public Client Client { get; set; }
    [Required]
    public DateTime PurchaseDate { get; set; }
    
    public decimal Price { get; set; }
}

