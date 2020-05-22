using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public class VehicleRepository
    {
        public List<Vehicle> _vehicleRepository = new List<Vehicle>();
        //Create Vehicle
        public void AddVehicle(Vehicle vehicle)
        {
            _vehicleRepository.Add(vehicle);
        }
        //List all vehicles
        public List<Vehicle> GetAll()
        {
            return _vehicleRepository;
        }
        //Read vehicle
        public Vehicle GetVehicleByModel(string model)
        {
            foreach (Vehicle vehicle in _vehicleRepository)
            {
                if (vehicle.Model == model)
                {
                    return vehicle;
                }
            }
            return null;
        }
        //Delete vehicle
        public bool RemoveVehicle(string model)
        {
            Vehicle vehicleToRemove = GetVehicleByModel(model);
            if (vehicleToRemove == null)
            {
                Console.WriteLine("This vehicle does not exist.");
                return false;
            }
            else
            {
                _vehicleRepository.Remove(vehicleToRemove);
                Console.WriteLine("Vehicle removed.");
                return true;

            }
        }
        //Update Vehicle
        public bool UpdateVehicleByModel(string model, Vehicle newValues)
        {
            Vehicle toUpdate = GetVehicleByModel(model);
            if (model == null)
            {
                Console.WriteLine("That vehicle doesn't exist.");
                return false;
            }
            else
            {
                toUpdate.Make = newValues.Make;
                toUpdate.Model = newValues.Model;
                toUpdate.Year = newValues.Year;
                toUpdate.SafetyRating = newValues.SafetyRating;
                toUpdate.CostNew = newValues.CostNew;
                return true;
            }
        }
        public bool UpdateElectricVehicleByModel(string model, Electric newValues)
        {
            UpdateVehicleByModel(model, newValues);
            Electric toUpdate = (Electric)GetVehicleByModel(model);
            if (model == null)
            {
                return false;
            }
            else
            {
                toUpdate.ChanceBatteryExplodesInCrash = newValues.ChanceBatteryExplodesInCrash;
                return true;
            }
        }

        public bool UpdateGasVehicleByModel(string model, Gas newValues)
        {
            UpdateVehicleByModel(model, newValues);
            Gas toUpdate = (Gas)GetVehicleByModel(model);
            if (model == null)
            {
                return false;
            }
            else
            {
                toUpdate.IsUsedForTowing = newValues.IsUsedForTowing;
                return true;
            }
        }
    }

}
