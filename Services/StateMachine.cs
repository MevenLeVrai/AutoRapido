using AutoRapido.Model;

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

        public StateMachine(ActionsService actionsService, MenuService menuService)
        {
            _currentState = MenuState.MainMenu;
            this._menuService = menuService;
            this._actionsService = actionsService;
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
                    _actionsService.DisplayCarsInfos();
                    break;

                case "DisplaySalesInfos":
                    _actionsService.DisplaySalesInfos();
                    break;

                case "AddMenu":
                    _currentState = MenuState.AddMenu;
                    break;

                case "Exit":
                    _currentState = MenuState.Exit;
                    break;

                // === Menu ajout ===
                case "AddNewClient":
                    _actionsService.AddNewClient();
                    break;

                case "AddNewCar":
                    _actionsService.AddNewCar();
                    break;

                case "AddNewSale":
                    _actionsService.AddNewSale();
                    break;

                case "Back":
                    _currentState = MenuState.MainMenu;
                    break;

                default:
                    Console.WriteLine("Action non reconnue !");
                    break;
            }
        }
    }
}
