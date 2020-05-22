using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public class GreenPlanUI
    {
        private readonly VehicleRepository _electricRepo = new VehicleRepository();
        private readonly VehicleRepository _gasRepo = new VehicleRepository();
        private readonly VehicleRepository _hybridRepo = new VehicleRepository();
        public void Run()
        {
            RunMenu();
        }
        public void RunMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome! What would you like to do today?\n" +
                "1. Add Vehicle to Directory\n" +
                "2. Update Vehicle Information\n" +
                "3. Remove Vehicle From Directory\n" +
                "4. Find vehicle\n" +
                "5. Compare vehicles\n" +
                "6. Exit");
            string selection = Console.ReadLine();
            bool keepRunning = true;
            while (keepRunning)
            {
                switch (selection)
                {
                    case "1":
                    case "Add":
                    case "add":
                        AddVehicle();
                        keepRunning = false;
                        break;
                    case "2":
                    case "Update":
                    case "update":
                        UpdateVehicle();
                        keepRunning = false;
                        break;
                    case "3":
                    case "Remove":
                    case "remove":
                        DeleteVehicle();
                        keepRunning = false;
                        break;
                    case "4":
                    case "Find":
                    case "find":
                        FindVehicle();
                        keepRunning = false;
                        break;
                    case "5":
                    case "Compare":
                    case "compare":
                        Compare();
                        keepRunning = false;
                        break;
                    case "6":
                    case "Exit":
                    case "exit":
                        keepRunning = false;
                        Console.WriteLine("Goodbye!");
                        Thread.Sleep(1500);
                        break;
                    default:
                        break; //Writes nothing, resets prompt.
                }
            }
        }
        public string GetVehicleClass()
        {
            Console.Clear();
            Console.WriteLine("Select vehicle class:\n" +
                "1. Electric\n" +
                "2. Gas\n" +
                "3. Hybrid");
            string selection = Console.ReadLine();
            string vehicleClass = "none";
            bool keepRunning = true;
            while (keepRunning)
            {
                switch (selection)
                {
                    case "1":
                    case "Electric":
                    case "electric":
                        vehicleClass = "Electric";
                        keepRunning = false;
                        break;
                    case "2":
                    case "Gas":
                    case "gas":
                        vehicleClass = "Gas";
                        keepRunning = false;
                        break;
                    case "3":
                    case "Hybrid":
                    case "hybrid":
                        vehicleClass = "Hybrid";
                        keepRunning = false;
                        break;
                    default:
                        break; //Writes nothing, resets prompt.
                }
            }
            return vehicleClass;
        }
        public string GetVehicleModel()
        {
            Console.WriteLine("What is the vehicle model?");
            return Console.ReadLine();
        }
        public Chance GetElectricChance()
        {
            Console.WriteLine("What is the chance of battery explosion in a high-impact crash?\n" +
                    "1. Low\n" +
                    "2. Medium\n" +
                    "3. High");
            string choice = Console.ReadLine();
            Chance chanceBatteryExplodesInCrash = Chance.None;
            bool keepRunning = true;
            while (keepRunning)
            {
                switch (choice)
                {
                    case "1":
                    case "Low":
                    case "low":
                        chanceBatteryExplodesInCrash = Chance.Low;
                        keepRunning = false;
                        break;
                    case "2":
                    case "Medium":
                    case "medium":
                        chanceBatteryExplodesInCrash = Chance.Medium;
                        keepRunning = false;
                        break;
                    case "3":
                    case "High":
                    case "high":
                        chanceBatteryExplodesInCrash = Chance.High;
                        keepRunning = false;
                        break;
                    default:
                        break;
                }
            }
            return chanceBatteryExplodesInCrash;
        }
        public bool GetGasTowing()
        {
            Console.WriteLine("Is this vehicle used for towing? Y/N:");
            string selection = Console.ReadLine();
            bool isUsedForTowing = false;
            bool continueRunning = true;
            while (continueRunning)
            {
                switch (selection)
                {
                    case "Y":
                    case "y":
                        isUsedForTowing = true;
                        continueRunning = false;
                        break;
                    case "N":
                    case "n":
                        isUsedForTowing = false;
                        continueRunning = false;
                        break;
                    default:
                        break;
                }
            }
            return isUsedForTowing;
        }
        public void AddVehicle()
        {
            string vehicleClass = GetVehicleClass();
            Console.WriteLine("Enter the following:\n" +
                "Vehicle Make:");
            string make = Console.ReadLine();
            Console.WriteLine("Vehicle Model:");
            string model = Console.ReadLine();
            Console.WriteLine("Year Released:");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Safety Rating:");
            double safetyRating = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Cost to Buy New:");
            double costNew = Convert.ToDouble(Console.ReadLine());
            if (vehicleClass == "Electric")
            {
                Chance chanceBatteryExplodesInCrash = GetElectricChance();
                Electric newElectric = new Electric(make, model, year, safetyRating, costNew, chanceBatteryExplodesInCrash);
                _electricRepo.AddVehicle(newElectric);
            }
            else if (vehicleClass == "Gas")
            {
                bool isUsedForTowing = GetGasTowing();
                Gas newGas = new Gas(make, model, year, safetyRating, costNew, isUsedForTowing);
                _gasRepo.AddVehicle(newGas);
            }
            else
            {
                Hybrid newHybrid = new Hybrid(make, model, year, safetyRating, costNew);
                _hybridRepo.AddVehicle(newHybrid);
            }
            Console.WriteLine("Vehicle added.");
            ReturnToMainMenu();
        }
        public void UpdateVehicle()
        {
            //TODO ask for vehicleClass, ask for model
            //TODO ask for base properties
            //TODO if don't need to update, leave blank press enter and will pass over updating that property
            //TODO if vehicleClass == "Electric", prompt for Electric property, else if same for "Gas"
            //TODO Update based on vehicleClass
            //TODO ReturnToMainMenu
        }
        public void DeleteVehicle()
        {
            string vehicleClass = GetVehicleClass();
            string model = GetVehicleModel();
            switch (vehicleClass)
            {
                case "Electric":
                _electricRepo.RemoveVehicle(model);
                    break;
                case "Gas":
                    _gasRepo.RemoveVehicle(model);
                    break;
                case "Hybrid":
                    _hybridRepo.RemoveVehicle(model);
                    break;
                default:
                    break;
            }
            ReturnToMainMenu();
        }
        public void FindVehicle()
        {
            string vehicleClass = GetVehicleClass();
            string model = GetVehicleModel();
            //TODO grab from approrpiate repository and write to console
            ReturnToMainMenu();
        }
        public void Compare()
        {
            string vehicleClass = GetVehicleClass();
            switch (vehicleClass)
            {
                case "Electric": //TODO Write _electricRepo to console in list
                case "Gas": //TODO Write _gasRepo to console in list
                case "Hybrid": //TODO Write _hybridRepo to console in list
                    break;
            }
        }
        public void ReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }
    }
}
