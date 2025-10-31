namespace AutoRapido.Model
{
    public class MenuOption
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string InternalName { get; set; } // Nom logique pour la gateway

        public MenuOption(int id, string label, string internalName)
        {
            Id = id;
            Label = label;
            InternalName = internalName;
        }
    }
}