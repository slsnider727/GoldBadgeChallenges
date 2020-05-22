using System;
using _06_GreenPlan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_RepoTests
{
    [TestClass]
    public class UnitTest1
    {
        public VehicleRepository _vehicleRepo = new VehicleRepository();
        [TestInitialize]
        public void SeedRepository()
        {
            Electric leaf = new Electric("Nissan", "Leaf", 2019, 4.9, 42000, Chance.Low);
            Electric tesla = new Electric("Tesla", "Model S", 2016, 4.8, 55000, Chance.Medium);
            Gas tundra = new Gas("Toyota", "Tundra", 2017, 4.6, 46000, true);
            Gas impala = new Gas("Chevrolet", "Impala", 2016, 4.7, 36000, false);
            Hybrid prius = new Hybrid("Toyota", "Prius", 2014, 4.6, 27000);
            _vehicleRepo.AddVehicle(leaf);
            _vehicleRepo.AddVehicle(tesla);
            _vehicleRepo.AddVehicle(tundra);
            _vehicleRepo.AddVehicle(impala);
            _vehicleRepo.AddVehicle(prius);

        }
        [TestMethod]
        public void GetAllShouldShowAppropriateCount()
        {
            int expected = 5;
            int actual = _vehicleRepo.GetAll().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddVehicleShouldIncreaseCount()
        {
            Hybrid volt = new Hybrid("Chevrolet", "Volt", 2018, 4.5, 36000);
            _vehicleRepo.AddVehicle(volt);
            int expected = 6;
            int actual = _vehicleRepo.GetAll().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetByModelShouldReturnCorrectVehicle()
        {
            string actual = _vehicleRepo.GetVehicleByModel("Impala").Make;
            string expected = "Chevrolet";
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void RemoveShouldDecreaseCount()
        {
            int startingCount = _vehicleRepo.GetAll().Count;
            _vehicleRepo.RemoveVehicle("Model S");
            int expected = 4;
            Assert.AreEqual(expected, (startingCount - 1));
        }
        [TestMethod]
        public void UpdateVehicleShouldUpdate()
        {
            //TODO
        }
        [TestMethod]
        public void UpdateElectricVehicleShouldUpdate()
        {
            //TODO
        }
        [TestMethod]
        public void UpdateGasVehicleShouldUpdate()
        {
            //TODO
        }
    }
}
