using System;
using AutoRapido.Model;
using AutoRapido.Data;

namespace AutoRapido.Services
{
    public enum MenuState // TODO create external class 
    {
        MainMenu,
        AddMenu,
        Exit
    }

    public class StateMachine 
    {
        private MenuState _currentState;
        private readonly MenuService _menuService;
        private readonly ActionsService _actionsService;

        public StateMachine(ActionsService _actionsService, MenuService _menuService)
        {
            _currentState = MenuState.MainMenu;
            this._menuService = _menuService;
            this._actionsService = _actionsService;
        }

        public void Run()
        {
            while (_currentState != MenuState.Exit)
            {
                switch (_currentState)
                {
                    case MenuState.MainMenu:
                        HandleMenu(_menuService.GetMainMenu());
                        break;
                    case MenuState.AddMenu:
                        HandleMenu(_menuService.GetAddMenu());
                        break;
                }
            }

            Console.WriteLine("\nFin du programme. Merci d’avoir utilisé AutoRapido !");
        }

        private void HandleMenu(List<MenuOption> menuOptions)
        {
            Console.WriteLine("\n=== Menu AutoRapido ===");
            foreach (var option in menuOptions)
                Console.WriteLine($"{option.Id}) {option.Label}");

            Console.Write("Votre choix : ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out int choiceId))
            {
                var selectedOption = menuOptions.Find(o => o.Id == choiceId);
                if (selectedOption != null)
                    ProcessChoice(selectedOption.InternalName);
                else
                    Console.WriteLine("Choix invalide !");
            }
            else
            {
                Console.WriteLine("Entrée non reconnue !");
            }
        }

        private void ProcessChoice(string internalName)
        {
            switch (internalName)
            {
                // === Menu principal ===
                case "DisplayCarsInfos":
                    actionsService.DisplayCarsInfos();
                    break;

                case "DisplaySalesInfos":
                    actionsService.DisplaySalesInfos();
                    break;

                case "AddMenu":
                    currentState = MenuState.AddMenu;
                    break;

                case "Exit":
                    _currentState = MenuState.Exit;
                    break;

                // === Menu ajout ===
                case "AddNewClient":
                    actionsService.AddNewClient();
                    break;

                case "AddNewCar":
                    actionsService.AddNewCar();
                    break;

                case "AddNewSale":
                    actionsService.AddNewSale();
                    break;

                case "Back":
                    currentState = MenuState.MainMenu;
                    break;

                default:
                    Console.WriteLine("Action non reconnue !");
                    break;
            }
        }
    }
}
