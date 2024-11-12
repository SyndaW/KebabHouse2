namespace KebabHouse
{
    public class Kebab
    {
        public string Name { get; set; }
        public int Meat { get; set; }
        public int Salad { get; set; }
        public int Sauce { get; set; }

        public Kebab(string name, int meat, int salad, int sauce)
        {
            Name = name;
            Meat = meat;
            Salad = salad;
            Sauce = sauce;
        }
    }
}
