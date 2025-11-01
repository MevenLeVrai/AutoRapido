using System;
using AutoRapido.Data;
using AutoRapido.Model;
using Microsoft.EntityFrameworkCore;

namespace AutoRapido.Services
{
    public class ActionsService
    {   
        
        private readonly ConcessionDbContext _dbContext;
        public ActionsService(ConcessionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void VoirVoitures()
        {
            Console.WriteLine("\n Liste des voitures disponibles :\n");

            var cars = _dbContext.Cars.ToList(); // Récupération depuis la base
            {
                Console.WriteLine("Aucune voiture enregistrée pour le moment.\n");
            }
            
            foreach (var car in cars)
            {
                Console.WriteLine($"- {car.BrandName} {car.ModelName} ({car.FirstRegistrationYear})");
            }

            Console.WriteLine();
        }

        public void VoirVentes()
        {
            Console.WriteLine("\nHistorique des ventes :");
            Console.WriteLine("→ (Aucune vente enregistrée pour le moment)\n");
        }

        public void AjouterClient()
        {
            Console.WriteLine("\nFormulaire d’ajout client (simulation)...\n");
        }

        public void AjouterVoiture()
        {
            Console.WriteLine("\nFormulaire d’ajout voiture (simulation)...\n");
        }

        public void AjouterVente()
        {
            Console.WriteLine("Sélectionnez l'ID du client :");
            foreach (var c in _dbContext.Clients)
                Console.WriteLine($"{c.ClientId} - {c.FirstName} {c.LastName}");
            var clientInput = Console.ReadLine();

            Console.WriteLine("Sélectionnez l'ID de la voiture :");
            foreach (var v in _dbContext.Cars)
                Console.WriteLine($"{v.CarId} - {v.BrandName} {v.ModelName}");
            var carInput = Console.ReadLine();

            if (Guid.TryParse(clientInput, out var clientId) && Guid.TryParse(carInput, out var carId))
            {
                var purchase = new Purchase
                {
                    CarId = carId,
                    ClientId = clientId,
                    PurchaseDate = DateTime.UtcNow
                };
                _dbContext.Purchases.Add(purchase);
                _dbContext.SaveChanges();
                Console.WriteLine("Vente enregistrée !");
            }
            else
            {
                Console.WriteLine("Erreur de saisie !");
            }
        }

    }
}