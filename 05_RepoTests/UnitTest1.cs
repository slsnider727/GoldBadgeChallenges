using System;
using _05_Greeting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_RepoTests
{
    [TestClass]
    public class UnitTest1
    {
        public CustomerRepository _customerDirectory = new CustomerRepository();
        [TestInitialize]
        public void SeedRepository()
        {
            Customer one = new Customer("Smith", "Terry", CustomerType.Past);
            Customer two = new Customer("Jones", "Samantha", CustomerType.Current);
            Customer three = new Customer("Jones", "Jenny", CustomerType.Potential);
            Customer four = new Customer("Collins", "Phil", CustomerType.Past);
            Customer five = new Customer("Creevey", "Collin", CustomerType.Potential);
            _customerDirectory.AddCustomer(one);
            _customerDirectory.AddCustomer(two);
            _customerDirectory.AddCustomer(three);
            _customerDirectory.AddCustomer(four);
            _customerDirectory.AddCustomer(five);
        }
        [TestMethod]
        public void GetAllShouldShowProperCount()
        {
            int actual = _customerDirectory.GetAllCustomers().Count;
            int expected = 5;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void DisplayAllCustomersShouldDisplayInAlphaOrder()
        {
            _customerDirectory.DisplayAllCustomersByAlpha();
        }
        [TestMethod]
        public void AddCustomerShouldIncreaseCount()
        {
            Customer six = new Customer("Python", "Monty", CustomerType.Past);
            _customerDirectory.AddCustomer(six);
            int actual = _customerDirectory.GetAllCustomers().Count;
            int expected = 6;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void GetCustomerByNameShouldReturnThatCustomer()
        {
            Customer six = new Customer("Python", "Monty", CustomerType.Past);
            _customerDirectory.AddCustomer(six);
            Customer actual = _customerDirectory.GetCustomertByLastAndFirst("Python", "Monty");
            Assert.AreEqual(six, actual);
        }
        [TestMethod]
        public void RemoveCustomerShouldDecreaseRepoCount()
        {
            _customerDirectory.RemoveCustomerByName("Jones", "Jenny");
            int actual = _customerDirectory.GetAllCustomers().Count;
            int expected = 4;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void UpdateLastNameShouldChangeCustomerLastNameAndWillShowWhenPrinted()
        {
            string newLastName = "Weasley";
            _customerDirectory.UpdateCustomerLastName("Jones", "Jenny", newLastName);
            Customer customer = _customerDirectory.GetCustomertByLastAndFirst("Weasley", "Jenny");
            Assert.AreEqual(customer.LastName, newLastName);;
        }
        [TestMethod]
        public void UpdateFirstNameShouldChangeCustomerFirstName()
        {
            string newFirstName = "Jim";
            _customerDirectory.UpdateCustomerFirstName("Jones", "Jenny", newFirstName);
            Customer customer = _customerDirectory.GetCustomertByLastAndFirst("Jones", "Jim");
            Assert.AreEqual(customer.FirstName, newFirstName);
        }
        [TestMethod]
        public void UpdateCustomerTypeShouldChangeType()
        {
            CustomerType newCustomerType = CustomerType.Current;
            _customerDirectory.UpdateCustomerType("Jones", "Jenny", newCustomerType);
            Customer customer = _customerDirectory.GetCustomertByLastAndFirst("Jones", "Jenny");
            Assert.AreEqual(customer.CustomerType, newCustomerType);


        }
    }
}
