using System;
using _04_CompanyOutings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_RepoTests
{
    [TestClass]
    public class UnitTest1
    {
        public OutingRepository _outingRepo = new OutingRepository();
        [TestInitialize]
        public void SeedRepository()
        {
            Outing one = new Outing(EventType.Concert, 34, new DateTime(2020, 05, 10), 120.00m);
            Outing two = new Outing(EventType.Golf, 15, new DateTime(2020, 04, 15), 35.50m);
            Outing three = new Outing(EventType.AmusementPark, 38, new DateTime(2020, 01, 15), 195.75m);
            _outingRepo.AddOutingToList(one);
            _outingRepo.AddOutingToList(two);
            _outingRepo.AddOutingToList(three);
        }
        [TestMethod]
        public void DisplayAllShouldWriteAllOutingsToConsole()
        {
            _outingRepo.DisplayAllOutings();
        }
        [TestMethod]
        public void AddOutingShouldIncreaseRepoCount()
        {
            int expected = 3;
            int actual = _outingRepo.GetAllOutings().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetAllOneTypeShouldProduceProperCountOneType()
        {
            Outing four = new Outing(EventType.Golf, 5, new DateTime(2020, 03, 25), 17.50m);
            _outingRepo.AddOutingToList(four);
            int actual = _outingRepo.GetOutingsByType(EventType.Golf).Count;
            int expected = 2;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void CalculateCostForAllOutingsShouldGiveGrandTotal()
        {
            decimal actual = _outingRepo.CalculateTotalCostForAllOutings();
            decimal expected = 12051.00m;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void CalculateCostForAllOfOneTypeShouldGiveTypeTotal()
        {
            Outing four = new Outing(EventType.Golf, 5, new DateTime(2020, 03, 25), 17.50m);
            _outingRepo.AddOutingToList(four);
            decimal actual = _outingRepo.CalculateTotalCostForOutingType(EventType.Golf);
            decimal expected = 620.00m;
            Assert.AreEqual(actual, expected);
        }
    }
}
