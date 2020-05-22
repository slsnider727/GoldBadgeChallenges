using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class CafeUI
    {
        private readonly MenuRepository _menuRepository = new MenuRepository();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter your selection number:\n" +
                    "1. Show Full Menu\n" +
                    "2. Add Item To Menu\n" +
                    "3. Remove Itemm From Menu\n" +
                    "4. Exit"
                    );
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                    case "one":
                    case "One":
                        Console.Clear();
                        if (_menuRepository.IsEmpty())
                        {
                            Console.WriteLine("There are no items on the menu.");
                        }
                        else
                        {
                            _menuRepository.PrintMenu();
                        }
                        Console.WriteLine("Press any key to return to main menu.");
                        Console.ReadKey();
                        break;
                    case "2":
                    case "Two":
                    case "two":
                        Console.Clear();
                        AddMenuItem();
                        Console.ReadKey();
                        break;
                    case "3":
                    case "Three":
                    case "three":
                        RemoveMenuItem();
                        Console.ReadKey();
                        break;
                    case "4":
                    case "Four":
                    case "four":
                        Console.Clear();
                        continueToRun = false;
                        Console.WriteLine("Goodbye!");
                        Thread.Sleep(1500);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid option. Press any key to return to main menu.\n");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Enter item name:");
            string mealName = Console.ReadLine();
            Console.WriteLine("Enter item description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter ingredients separated by commas (ex. 'chicken, rice, cheese'):");
            string ingredients = Console.ReadLine();
            Console.WriteLine("Enter price in decimal form (ex. 7.25):");
            double price = Convert.ToDouble(Console.ReadLine());
            MenuItem newItem = new MenuItem(mealName, description, ingredients, price);
            _menuRepository.AddItemToMenu(newItem);
            Console.WriteLine("Item added! Press any key to continue.");
        }
        private void RemoveMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Enter meal number:");
            int mealNumber = Convert.ToInt32(Console.ReadLine());
            bool removed = _menuRepository.RemoveItemFromMenu(mealNumber);
            if (removed)
            {
                Console.WriteLine("Item removed. Press any key to continue.");
            }
            else
            {
                Console.WriteLine("No item exists with that number. Press any key to return to main menu and try again.");
            }
        }
    }
}
