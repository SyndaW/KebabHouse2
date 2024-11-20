using System;

namespace KebabHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Sklad sklad = new Sklad(1000, 1000, 1000); // Počáteční zásoby masa, salátu, omáček

            Console.WriteLine("Vítejte v KebabHouse!");

            // Menu s různými nabídkami kebabu
            Console.WriteLine("Vyberte číslo menu:");
            Console.WriteLine("1. Kebab 'Classic' s 100g masa, 50g salátu, 30g omáčky");
            Console.WriteLine("2. Kebab 'Big Beef' s 150g masa, 60g salátu, 35g omáčky");
            Console.WriteLine("3. Kebab 'Spicy' s 200g masa, 70g salátu, 40g omáčky");
            Console.WriteLine("4. Kebab 'Supreme' s 250g masa, 80g salátu, 45g omáčky");
            Console.WriteLine("5. Kebab 'Monster' s 300g masa, 90g salátu, 50g omáčky");
            Console.WriteLine("6. Zkontrolovat zásoby");
            Console.WriteLine("7. Doplňte zásoby");

            int choice = 0;
            bool validChoice = false;

            // Robustní validace vstupu
            while (!validChoice)
            {
                Console.Write("Zadejte číslo menu (1-7): ");
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out choice) || choice < 1 || choice > 7)
                {
                    Console.WriteLine("Neplatná volba, zadejte číslo mezi 1 a 7.");
                }
                else
                {
                    validChoice = true;
                }
            }

            Kebab? selectedKebab = null;

            // Vybereme Kebab podle čísla menu
            switch (choice)
            {
                case 1:
                    selectedKebab = new Kebab("Classic", 100, 50, 30);
                    break;
                case 2:
                    selectedKebab = new Kebab("Big Beef", 150, 60, 35);
                    break;
                case 3:
                    selectedKebab = new Kebab("Spicy", 200, 70, 40);
                    break;
                case 4:
                    selectedKebab = new Kebab("Supreme", 250, 80, 45);
                    break;
                case 5:
                    selectedKebab = new Kebab("Monster", 300, 90, 50);
                    break;
                case 6:
                    // Zobrazí aktuální stav zásob
                    Console.WriteLine($"Aktuální zásoby - Maso: {sklad.Meat}g, Salát: {sklad.Salad}g, Omáčka: {sklad.Sauce}g");
                    return;  // Předčasně ukončí program
                case 7:
                    // Doplňování zásob
                    Console.WriteLine("Zadejte množství masa, salátu a omáčky pro doplnění zásob:");
                    try
                    {
                        Console.Write("Maso (g): ");
                        int meatAdd = int.Parse(Console.ReadLine() ?? "0");  // Bezpečně ošetří prázdný vstup
                        Console.Write("Salát (g): ");
                        int saladAdd = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Omáčka (g): ");
                        int sauceAdd = int.Parse(Console.ReadLine() ?? "0");

                        sklad.Restock(meatAdd, saladAdd, sauceAdd);
                        Console.WriteLine($"Zásoby byly doplněny! Maso: {meatAdd}g, Salát: {saladAdd}g, Omáčka: {sauceAdd}g");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Neplatný formát. Ujistěte se, že zadáváte čísla.");
                    }
                    return;  // Předčasně ukončí program
            }

            // Kontrola, zda jsou na skladě dostatečné zásoby
            if (selectedKebab != null &&
                sklad.Meat >= selectedKebab.Meat &&
                sklad.Salad >= selectedKebab.Salad &&
                sklad.Sauce >= selectedKebab.Sauce)
            {
                // Odbavení objednávky
                sklad.Consume(selectedKebab);
                Console.WriteLine($"Objednávka byla přijata! Kebab '{selectedKebab.Name}' s {selectedKebab.Meat}g masa, {selectedKebab.Salad}g salátu a {selectedKebab.Sauce}g omáčky.");
            }
            else if (selectedKebab != null)
            {
                Console.WriteLine("Není dostatek zásob pro tuto objednávku.");
            }

            Console.WriteLine($"Aktuální zásoby - Maso: {sklad.Meat}g, Salát: {sklad.Salad}g, Omáčka: {sklad.Sauce}g");
        }
    }
}
