namespace KebabHouse
{
    class Kebab
    {
        public string Name { get; }
        public int Meat { get; }
        public int Salad { get; }
        public int Sauce { get; }

        public Kebab(string name, int meat, int salad, int sauce)
        {
            Name = name;
            Meat = meat;
            Salad = salad;
            Sauce = sauce;
        }
    }
}
