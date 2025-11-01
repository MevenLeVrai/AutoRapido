using AutoRapido.Model;

namespace AutoRapido.Services
{
    public class MenuService
    {
        // This service manages the menus and their content.
        public List<MenuOption> GetMainMenu()
        {
            return new List<MenuOption>
            {
                new (1, "Voir la liste des voitures", "VoirVoitures"),
                new (2, "Voir l’historique des ventes", "VoirVentes"),
                new (3, "Menu Ajouter", "MenuAjout"),
                new (4, "Quitter", "Exit")
            };
        }

        public List<MenuOption> GetAddMenu()
        {
            return new List<MenuOption>
            {
                new (1, "Ajouter un client", "AjouterClient"),
                new (2, "Ajouter une voiture", "AjouterVoiture"),
                new (3, "Ajouter une vente", "AjouterVente"),
                new (4, "Retour au menu principal", "Retour")
            };
        }
    }
}