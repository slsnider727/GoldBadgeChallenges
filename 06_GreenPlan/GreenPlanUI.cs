using System;
using System.Collections.Generic;
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
        //TODO method to ask for/get vehicle model
        public void AddVehicle()
        {
            string vehicleClass = GetVehicleClass();
            //TODO prompt for base properties
            //TODO if vehicleClass == "Electric", prompt for Electric property, else if same for "Gas"
            //TODO if statement to assign to appropriate repo
        }
        public void UpdateVehicle()
        {
            //TODO ask for vehicleClass, ask for model
            //TODO ask for base properties
            //TODO if don't need to update, leave blank press enter and will pass over updating that property
            //TODO if vehicleClass == "Electric", prompt for Electric property, else if same for "Gas"
            //Update based on vehicleClass
        }
        public void DeleteVehicle()
        {
            //TODO ask for vehicleClass, ask for model
            //Remove from appropriate repo
        }
        public void FindVehicle()
        {
            //TODO ask for vehicleClass, ask for model
            //Find from appropriate Repo and write to console
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
    }
}
