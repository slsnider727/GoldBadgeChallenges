using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepository
    {
        public List<MenuItem> _menuRepository = new List<MenuItem>();
        //Add item to menu
        public void AddItemToMenu(MenuItem item)
        {
            _menuRepository.Add(item);
            item.MealNumber = _menuRepository.Count(); //updates meal numbers so they are consecutive
                                                       //when menu is printed rather than random numbers
        }
        //Find item by ID
        public MenuItem FindItemByID(int mealNumber)
        {
            foreach (MenuItem item in _menuRepository)
            {
                if (item.MealNumber == mealNumber)
                {
                    return item;
                }
            }
            return null;
        }
        //Delete item from menu
        public bool RemoveItemFromMenu(int mealNumber)
        {
            MenuItem itemToRemove = null;
            foreach (MenuItem item in _menuRepository)
            {
                if (mealNumber == item.MealNumber)
                {
                    itemToRemove = item;
                }
            }
            if (itemToRemove == null)
            {
                return false;
            }
            else
            {
                _menuRepository.Remove(itemToRemove);
                int i = 1;
                foreach (MenuItem remainingItem in _menuRepository) //Rewrites meal numbers to consecutive for printing
                {
                    remainingItem.MealNumber = i;
                    i++;
                }
                return true;
            }
        }
        //Get All Menu Items
        public List<MenuItem> GetMenu()
        {
            return _menuRepository;
        }
        //Print Menu
        public void PrintMenu()
        {
            foreach (MenuItem item in _menuRepository)
            {
                Console.WriteLine($"Meal: #{item.MealNumber}");
                Console.WriteLine($"Name: {item.MealName}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Ingredients: {item.Ingredients}");
                Console.WriteLine($"Price: ${item.Price}\n");
            }
        }
        //Is Menu Empty
        public bool IsEmpty()
        {
            if (_menuRepository.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
