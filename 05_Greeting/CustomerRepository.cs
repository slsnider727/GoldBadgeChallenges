using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greeting
{
    public class CustomerRepository
    {
        public List<Customer> _customerRepo = new List<Customer>();
        //Get all customers in repository
        public List<Customer> GetAllCustomers()
        {
            return _customerRepo;
        }
        //Display all Customers in alphabetical order
        public void DisplayAllCustomersByAlpha()
        {
            List<Customer> sorted = _customerRepo.OrderBy(s => s.LastName).ThenBy(s => s.FirstName).ToList(); //Creates a pseudo-copy of list and returns it in the order I want. Not a sort-in-place.
            Console.WriteLine($"{"Last",-15}{"First",-15}{"Type",-15}{"E-mail"}");
            foreach (Customer customer in sorted)
            {
                Console.Write($"{customer.LastName,-15}");
                Console.Write($"{customer.FirstName,-15}");
                Console.Write($"{customer.CustomerType,-15}");
                Console.Write($"{customer.Email}\n");
            }
        }
        //Add Customer to Repository
        public bool AddCustomer(Customer customer)
        {
            int startingCount = _customerRepo.Count();
            _customerRepo.Add(customer);
            bool wasAdded = _customerRepo.Count() == startingCount + 1;
            return wasAdded;
        }
        //Get Customer by name
        public Customer GetCustomertByLastAndFirst(string lastName, string firstName)
        {
            foreach (Customer customer in _customerRepo)
            {
                if (customer.LastName == lastName && customer.FirstName == firstName)
                {
                    return customer;
                }
            }
            return null;
        }
        //Delete customer from Repository
        public bool RemoveCustomerByName(string lastName, string firstName)
        {
            Customer customerToRemove = GetCustomertByLastAndFirst(lastName, firstName);
            if (customerToRemove == null)
            {
                Console.WriteLine("No customer by that name exists.");
                return false;
            }
            else
            {
                _customerRepo.Remove(customerToRemove);
                Console.WriteLine("Customer removed.");
                return true;
            }
        }
        //Update customer info
        public bool UpdateCustomerLastName(string lastName, string firstName, string newLastName)
        {
            Customer customer = GetCustomertByLastAndFirst(lastName, firstName);

            if (customer == null)
            {
                Console.WriteLine("No customer by that name exists.");
                return false;
            }
            else
            {
                customer.LastName = newLastName;
                return true;
            }
        }
        public bool UpdateCustomerFirstName(string lastName, string firstName, string newFirstName)
        {
            Customer customer = GetCustomertByLastAndFirst(lastName, firstName);

            if (customer == null)
            {
                Console.WriteLine("No customer by that name exists.");
                return false;
            }
            else
            {
                customer.FirstName = newFirstName;
                return true;
            }
        }
        public bool UpdateCustomerType(string lastName, string firstName, CustomerType newCustomerType)
        {
            Customer customer = GetCustomertByLastAndFirst(lastName, firstName);

            if (customer == null)
            {
                Console.WriteLine("No customer by that name exists.");
                return false;
            }
            else
            {
                customer.CustomerType = newCustomerType;
                return true;
            }
        }
    }
}
