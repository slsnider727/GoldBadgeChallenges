using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_CompanyOutings
{
    public class OutingUI
    {
        private readonly OutingRepository _outingRepo = new OutingRepository();
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
                Console.WriteLine(
                    "Enter your selection number:\n" +
                    "1. Display All Outings\n" +
                    "2. Add Outing to List\n" +
                    "3. Calculate Cost of All Outings\n" +
                    "4. Calculate Cost of All Outings of One Type\n" +
                    "5. Exit"
                    );
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                    case "one":
                    case "One":
                        Console.Clear();
                        if (_outingRepo.IsEmpty())
                        {
                            Console.WriteLine("There are no outings on the list.");
                        }
                        else
                        {
                            _outingRepo.DisplayAllOutings();
                        }
                        Console.WriteLine("\n\n\nPress any key to return to main menu.");
                        Console.ReadKey();
                        break;
                    case "2":
                    case "Two":
                    case "two":
                        Console.Clear();
                        AddOuting();
                        break;
                    case "3":
                    case "Three":
                    case "three":
                        Console.Clear();
                        _outingRepo.CalculateTotalCostForAllOutings();
                        Console.ReadKey();
                        break;
                    case "4":
                    case "Four":
                    case "four":
                        CalculateTypeCost();
                        break;
                    case "5":
                    case "Five":
                    case "five":
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
        private EventType GetOutingType()
        {
            Console.Clear();
            Console.WriteLine("Select Outing Type\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");
            string choice = Console.ReadLine();
            EventType eventType = EventType.None; //Assigned but will be overwritten by selection. None is not a possible selection.
            bool keepRunning = true;
            while (keepRunning)
            {
                switch (choice)
                {
                    case "1":
                    case "Golf":
                    case "golf":
                        eventType = EventType.Golf;
                        keepRunning = false;
                        break;
                    case "2":
                    case "Bowling":
                    case "bowling":
                        eventType = EventType.Bowling;
                        keepRunning = false;
                        break;
                    case "3":
                    case "Amusement Park":
                    case "amusement park":
                        eventType = EventType.AmusementPark;
                        keepRunning = false;
                        break;
                    case "4":
                    case "Concert":
                    case "concert":
                        eventType = EventType.Concert;
                        keepRunning = false;
                        break;
                    default:
                        //Writes nothing, resets menu
                        break;
                }
            }
            return eventType;
        }
        private void AddOuting()
        {
            Console.Clear();
            EventType eventType = GetOutingType();
            Console.WriteLine("How many people attended?");
            int attended = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("When did the event take place? mm/dd/yyyy:");
            DateTime dateOfEvent = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("What was the cost per person? (decimal form, e.g. 25.99)");
            decimal costPerPerson = Convert.ToDecimal(Console.ReadLine());
            Outing newOuting = new Outing(eventType, attended, dateOfEvent, costPerPerson);
            _outingRepo.AddOutingToList(newOuting);
            Console.WriteLine("Outing added to list. Press any key to return to the main menu.");
            Console.ReadKey();
        }
        private void CalculateTypeCost()
        {
            EventType eventType = GetOutingType();
            _outingRepo.CalculateTotalCostForOutingType(eventType);
            Console.ReadKey();
        }
    }
}
