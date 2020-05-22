using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_Claims
{
    class ClaimUI
    {
        private readonly ClaimRepository _claimRepo = new ClaimRepository();

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
                Console.WriteLine("Choose an option from the menu: \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                    case "One":
                    case "one":
                        Console.Clear();
                        if (_claimRepo.GetAllClaims().Count == 0)
                        {
                            Console.WriteLine("There are no open claims at this time. Press any key to return to the main menu.");
                            Console.ReadKey();
                        }
                        else
                        {
                            _claimRepo.SeeAllClaims();
                            Console.WriteLine("\n\n\n");
                            ReturnToMainMenu();
                        }
                        break;
                    case "2":
                    case "Two":
                    case "two":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                    case "Three":
                    case "three":
                        EnterANewClaim();
                        break;
                    case "4":
                    case "Four":
                    case "four":
                    case "Exit":
                    case "exit":
                        continueToRun = false;
                        Console.WriteLine("Goodbye!");
                        Thread.Sleep(1500);
                        break;
                    default:
                        //Writes nothing, resets menu.
                        break;
                }
            }
        }
        public void ReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }
        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            if (_claimRepo.GetAllClaims().Count > 0)
            {
                Claim nextClaim = _claimRepo.GetNextClaim();
                Console.WriteLine("Do you want to deal with this claim now(y/n)?");
                string answer = Console.ReadLine();
                bool keepRunning = true;
                while (keepRunning)
                {
                    switch (answer)
                    {
                        case "Y":
                        case "y":
                        case "yes":
                        case "Yes":
                            _claimRepo.DequeueClaim();
                            Console.WriteLine("Thank you.");
                            Console.ReadKey();
                            keepRunning = false;
                            break;
                        case "N":
                        case "n":
                        case "no":
                        case "No":
                            Console.WriteLine("Okay.");
                            keepRunning = false;
                            break;
                        default:
                            //Writes nothing, resets menu.
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no open claims at this time.");
            }
            ReturnToMainMenu();
        }
        public void EnterANewClaim()
        {
            Console.Clear();
            Console.WriteLine("Enter the following:\n");
            Console.WriteLine("Claim ID:");
            int claimID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Select the claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string choice = Console.ReadLine();
            ClaimType claimType = ClaimType.None; //Assigned but will be overwritten by selection. None is not a possible selection.
            bool keepRunning = true;
            while (keepRunning)
            {
                switch (choice)
                {
                    case "1":
                    case "car":
                    case "Car":
                        claimType = ClaimType.Car;
                        keepRunning = false;
                        break;
                    case "2":
                    case "Home":
                    case "home":
                        claimType = ClaimType.Home;
                        keepRunning = false;
                        break;
                    case "3":
                    case "Theft":
                    case "theft":
                        claimType = ClaimType.Theft;
                        keepRunning = false;
                        break;
                    default:
                        //Writes nothing, resets menu
                        break;
                }
            }
            Console.WriteLine("Claim Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Amount of damage in decimal form, e.g. 400.75:");
            decimal claimAmount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Date of Incident (mm/dd/yyyy):");
            DateTime dateOfIncident = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Date of Claim (mm/dd/yyyy):");
            DateTime dateOfClaim = Convert.ToDateTime(Console.ReadLine());
            Claim newClaim = new Claim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim);
            if (newClaim.IsValid)
            {
                Console.WriteLine("This claim is valid.");
            }
            else
            {
                Console.WriteLine("This claim is not valid.");
            }
            _claimRepo.AddClaim(newClaim);
            Console.WriteLine("Claim successfully added.");
            ReturnToMainMenu();
        }
    }
}
