using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgeUI
    {
        private readonly BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello, Security Admin. What would you like to do?\n" +
                    "1. Add A Badge\n" +
                    "2. Edit A Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        Console.Clear();
                        _badgeRepo.SeeAllBadges();
                        Console.WriteLine("\n\n\n Press any key to return to main menu.");
                        Console.ReadKey();
                        break;
                    case "4":
                        continueToRun = false;
                        Console.WriteLine("Goodbye!");
                        Thread.Sleep(1500);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void AddABadge()
        {
            Console.Clear();
            Console.WriteLine("What is the number on the badge?");
            int badgeID = Convert.ToInt32(Console.ReadLine());
            List<string> emptyList = new List<string>();
            _badgeRepo.CreateNewBadge(badgeID);
            AddDoor(badgeID);
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Any other doors? Y/N:");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "Y":
                    case "y":
                        AddDoor(badgeID);
                        break;
                    case "N":
                    case "n":
                        Console.WriteLine("Badge finished. Press any key to return to main menu.");
                        Console.ReadKey();
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void AddDoor(int badgeID)
        {
            Console.WriteLine("List a door that it needs access to:");
            string door = Console.ReadLine();
            _badgeRepo.AddAccessToBadge(badgeID, door);
        }
        public void EditABadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update?");
            int badgeID = Convert.ToInt32(Console.ReadLine());
            if (_badgeRepo.ContainsKey(badgeID))
            {
                bool keepRunning = true;
                while (keepRunning)
                {
                    Console.Clear();
                    Console.WriteLine($"What would you like to do with badge {badgeID}?\n" +
                        "1. Add a door\n" +
                        "2. Remove a door\n" +
                        "3. Remove all access\n" +
                        "4. Return to main menu");
                    string selection = Console.ReadLine();
                    switch (selection)
                    {
                        case "1":
                            AddDoor(badgeID);
                            Console.WriteLine("Door added. Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("Current badge:");
                            _badgeRepo.SeeOneBadge(badgeID);
                            Console.WriteLine("Which door would you like to remove?");
                            string door = Console.ReadLine();
                            _badgeRepo.RemoveDoorFromBadge(badgeID, door);
                            Console.WriteLine("Access removed. Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case "3":
                            _badgeRepo.EraseAllAccess(badgeID);
                            Console.WriteLine("All access removed. Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case "4":
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No badge exists with this number. Return to main menu and add badge.");
                Console.ReadKey();
            }
        }
    }
}
