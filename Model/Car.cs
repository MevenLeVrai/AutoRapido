using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoRapido.Model;
using AutoRapido.Utils;

/*Fiche voiture 
    - UUID
    - Marque
    - Modele
    - Annee
    - Prix HT
    - Couleur
    - Etat (Vendu/A vendre)
    - Liste des propriétaires
*/

public class Car
{
    
    [Key]
    public Guid CarId { get; set; } = Guid.NewGuid();

    [Required]
    public String BrandName {
        get;
        set;
    }
    
    [Required]
    public String ModelName { get; set;}  
    
    [Required]
    public DateTime FirstRegistrationYear {get; set; }
    
    [Required]
    public decimal Price {get; set;}
    
    [Required]
    public String Color {get; set;}

    [Required]
    public Boolean IsSold {get; set;}

    [Required]
    public ICollection<Client> OwnerList { get; set; } = new List<Client>();
}