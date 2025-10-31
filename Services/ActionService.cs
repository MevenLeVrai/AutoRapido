using System;
using AutoRapido.Data;
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
            var carWithOwner = _dbContext.Cars
                .Include(c => c.OwnerList) // si Car a une navigation vers Client
                .ToList();
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
            Console.WriteLine("\n📜 Historique des ventes :");
            Console.WriteLine("→ (Aucune vente enregistrée pour le moment)\n");
        }

        public void AjouterClient()
        {
            Console.WriteLine("\n👤 Formulaire d’ajout client (simulation)...\n");
        }

        public void AjouterVoiture()
        {
            Console.WriteLine("\n🚘 Formulaire d’ajout voiture (simulation)...\n");
        }

        public void AjouterVente()
        {
            Console.WriteLine("\n💰 Formulaire d’ajout vente (simulation)...\n");
        }
    }
}