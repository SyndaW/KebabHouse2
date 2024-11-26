namespace KebabHouse
{
    class Sklad
    {
        public int Meat { get; private set; }
        public int Salad { get; private set; }
        public int Sauce { get; private set; }

        public Sklad(int meat, int salad, int sauce)
        {
            Meat = meat;
            Salad = salad;
            Sauce = sauce;
        }

        public void Consume(Kebab kebab)
        {
            if (Meat < kebab.Meat || Salad < kebab.Salad || Sauce < kebab.Sauce)
                throw new InvalidOperationException("Nedostatek zásob.");

            Meat -= kebab.Meat;
            Salad -= kebab.Salad;
            Sauce -= kebab.Sauce;
        }

        public void Restock(int meat, int salad, int sauce)
        {
            if (meat < 0 || salad < 0 || sauce < 0)
                throw new ArgumentException("Zadané množství musí být nezáporné.");

            Meat += meat;
            Salad += salad;
            Sauce += sauce;
        }
    }
}
