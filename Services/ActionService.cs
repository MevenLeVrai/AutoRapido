using System;
using AutoRapido.Data;
using AutoRapido.Model;
using AutoRapido.Utils;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AutoRapido.Services
{
    public class ActionsService
    {   
        
        private readonly ConcessionDbContext _dbContext;
        public ActionsService(ConcessionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DisplayCarsInfos()
        {
            Console.WriteLine("\n Liste des voitures disponibles :\n");

            var cars = _dbContext.Cars.ToList(); // Get from database
            {
                Console.WriteLine("Aucune voiture enregistrée pour le moment.\n");
            }
            
            foreach (var car in cars)
            {
                Console.WriteLine($"- {car.BrandName} {car.ModelName} ({car.FirstRegistrationYear})");
            }

            Console.WriteLine();
        }

        public void DisplaySalesInfos()
        {
            Console.WriteLine("\n📜 Historique des ventes :");
            Console.WriteLine("→ (Aucune vente enregistrée pour le moment)\n");
        }

        public void AddNewClient()
        {
            Console.WriteLine("\n👤 Formulaire d’ajout client (simulation)...\n");
        }
        public void AddNewCar()
        {
            Console.Write("=== Formulaire d'ajout d'une nouvelle voiture === ");
            var newCar = new Car();

            Console.Write("Marque de la voiture : ");
            newCar.BrandName = Console.ReadLine();

            Console.Write("Modèle de la voiture : ");
            newCar.ModelName = Console.ReadLine();

            Console.Write("Année de mise en circulation : ");
            string year = Console.ReadLine();
            newCar.FirstRegistrationYear = DateTimeUtils.ConvertToDateTime(year);

            Console.Write("Prix de la voiture : ");
            if (decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal price))
                newCar.Price = price;
            else
            {
                Console.WriteLine("Prix invalide.");
                newCar.Price = 0;   
            }

            Console.Write("Couleur de la voiture : ");
            newCar.Color = Console.ReadLine();

            Console.Write("La voiture est-elle vendue ? (true/false) : ");
            if (bool.TryParse(Console.ReadLine(), out bool isSold))
                newCar.IsSold = isSold;
            else
                newCar.IsSold = false;

            _dbContext.Cars.Add(newCar);
            _dbContext.SaveChanges();

            Console.WriteLine("\nNouvelle voiture ajoutée avec succès !");
        }


        public void AddNewSale()
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