namespace AutoRapido.Model
{
    public class MenuOption
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string InternalName { get; set; } // Internal Name used by the Gateway.

        public MenuOption(int id, string label, string internalName)
        {
            Id = id;
            Label = label;
            InternalName = internalName;
        }
    }
}