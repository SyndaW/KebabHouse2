namespace KebabHouse
{
    public class Sklad
    {
        public int Meat { get; set; }
        public int Salad { get; set; }
        public int Sauce { get; set; }

        public Sklad(int meat, int salad, int sauce)
        {
            Meat = meat;
            Salad = salad;
            Sauce = sauce;
        }

        // Funkce pro kontrolu zásob a odbavení objednávky
        public void Consume(Kebab kebab)
        {
            Meat -= kebab.Meat;
            Salad -= kebab.Salad;
            Sauce -= kebab.Sauce;
        }

        // Funkce pro doplnění zásob
        public void Restock(int meatAdd, int saladAdd, int sauceAdd)
        {
            Meat += meatAdd;
            Salad += saladAdd;
            Sauce += sauceAdd;
        }
    }
}
