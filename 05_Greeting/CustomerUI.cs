using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_Greeting
{
    public class CustomerUI
    {
        private readonly CustomerRepository _customerRepo = new CustomerRepository();
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
                    "1. View All Customers \n" +
                    "2. Add Customer To Directory \n" +
                    "3. Remove Customer From Directory \n" +
                    "4. Update Customer Profile\n" +
                    "5. Exit");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                    case "One":
                    case "one":
                        Console.Clear();
                        if (_customerRepo.GetAllCustomers().Count == 0)
                        {
                            Console.WriteLine("This directory is empty. Press any key to return to the main menu.");
                            Console.ReadKey();
                        }
                        else
                        {
                            _customerRepo.DisplayAllCustomersByAlpha();
                            Console.WriteLine("\n\n\n");
                            ReturnToMainMenu();
                        }
                        break;
                    case "2":
                    case "Two":
                    case "two":
                        AddNewCustomer();
                        break;
                    case "3":
                    case "Three":
                    case "three":
                        RemoveCustomer();
                        break;
                    case "4":
                    case "Four":
                    case "four":
                        UpdateCustomerProfile();
                        break;
                    case "5":
                    case "Five":
                    case "five":
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
        public CustomerType GetCustomerType()
        {
            Console.WriteLine("Select Customer Status:\n" +
                "1. Past\n" +
                "2. Current\n" +
                "3. Potential");
            string selection = Console.ReadLine();
            CustomerType customerType = CustomerType.None;
            bool keepRunning = true;
            while (keepRunning)
            {
                switch (selection)
                {
                    case "1":
                    case "Past":
                    case "past":
                        customerType = CustomerType.Past;
                        keepRunning = false;
                        break;
                    case "2":
                    case "Current":
                    case "current":
                        customerType = CustomerType.Current;
                        keepRunning = false;
                        break;
                    case "3":
                    case "Potential":
                    case "potential":
                        customerType = CustomerType.Potential;
                        keepRunning = false;
                        break;
                    default:
                        //Writes nothing, resets menu
                        break;
                }
            }
            return customerType;
        }
        public void AddNewCustomer()
        {
            Console.Clear();
            Console.WriteLine("Customer's Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Customer's First Name:");
            string firstName = Console.ReadLine();
            CustomerType customerType = GetCustomerType();
            Customer newCustomer = new Customer(lastName, firstName, customerType);
            _customerRepo.AddCustomer(newCustomer);
            Console.WriteLine("Customer added.");
            ReturnToMainMenu();
        }
        public void RemoveCustomer()
        {
            Console.Clear();
            Console.WriteLine("Customer's Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Customer's First Name:");
            string firstName = Console.ReadLine();
            _customerRepo.RemoveCustomerByName(lastName, firstName);
            ReturnToMainMenu();
        }
        public void UpdateCustomerProfile()
        {
            Console.Clear();
            Console.WriteLine("Let's find the customer you want to update.\n" +
                "Enter customer's last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter customer's first name:");
            string firstName = Console.ReadLine();
            Customer customerToUpdate = _customerRepo.GetCustomertByLastAndFirst(lastName, firstName);
            if (customerToUpdate == null)
            {
                Console.WriteLine("No customer by that name exists.");
                ReturnToMainMenu();
            } 
            else
            {
            Console.Clear();
            Console.WriteLine("What would you like to update?\n" +
                "1. Last Name\n" +
                "2. First Name\n" +
                "3. Customer Status");
            string selection = Console.ReadLine();
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                switch (selection)
                {
                    case "1":
                        Console.WriteLine("Enter new last name:");
                        string newLastName = Console.ReadLine();
                        _customerRepo.UpdateCustomerLastName(lastName, firstName, newLastName);
                        keepRunning = false;
                        break;
                    case "2":
                        Console.WriteLine("Enter new first name");
                        string newFirstName = Console.ReadLine();
                        _customerRepo.UpdateCustomerFirstName(lastName, firstName, newFirstName);
                        keepRunning = false;
                        break;
                    case "3":
                        CustomerType newCustomerType = GetCustomerType();
                        _customerRepo.UpdateCustomerType(lastName, firstName, newCustomerType);
                        keepRunning = false;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Customer info updated.");
            ReturnToMainMenu();
            }
        }
        public void ReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }
    }
}
