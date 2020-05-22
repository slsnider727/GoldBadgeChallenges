using System;
using System.Collections.Generic;
using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_RepositoryTests
{
    [TestClass]
    public class UnitTest1
    {
        public MenuRepository _menu = new MenuRepository();
        [TestInitialize]
        public void SeedRepository()
        {
            MenuItem shrimpTacos = new MenuItem("Shrimp Tacos", "delicious tacos with shrimp", "shrimp, tortillas", 7.50);
            MenuItem generalTsos = new MenuItem("General Tso's Chicken", "what boring people order", "chicken, rice", 9.00);
            MenuItem vegRoll = new MenuItem("Veggie Spring Roll", "vegetables in a blanket", "vegetables, soy wrapper", 4.25);

            _menu.AddItemToMenu(shrimpTacos);
            _menu.AddItemToMenu(generalTsos);
            _menu.AddItemToMenu(vegRoll);
        }
        [TestMethod]
        public void AddItemShouldIncreaseMenuCount()
        {
            int actual = _menu.GetMenu().Count;
            int expected = 3;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void FindItemByIDShouldGetItem()
        {
            MenuItem stirFry = new MenuItem("Stir Fry Noodles", "slurpy noodles", "noodles, flavor", 5.50);
            _menu.AddItemToMenu(stirFry);
            MenuItem testItem = _menu.FindItemByID(4);
            Assert.AreEqual(testItem, stirFry);
        }
        [TestMethod]
        public void RemoveItemShouldDecreaseMenuCountAndUpdateMealNumbers()
        {
            List<MenuItem> myMenu = _menu.GetMenu();
            _menu.RemoveItemFromMenu(2);
            int expected = 2;
            int actual = _menu.GetMenu().Count;
            Assert.AreEqual(expected, actual);
            _menu.PrintMenu();
        }
        [TestMethod]
        public void PrintMenuShouldPrintAllItemsToConsole()
        {
            _menu.PrintMenu();
        }
    }
}
