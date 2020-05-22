using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyOutings
{
    public class OutingRepository
    {
        public List<Outing> _outingRepo = new List<Outing>();
        //Display all outings to console
        public void DisplayAllOutings()
        {
            Console.WriteLine($"{"Event Type", -13}{"Number Attended", -18}{"Event Date", -15}{"Cost Per Person", -18}{"Total Event Cost"}");
            foreach (Outing outing in _outingRepo)
            {
                Console.Write($"{ outing.EventType, -13}");
                Console.Write($"{outing.AttendeeCount, -18}");
                Console.Write($"{outing.EventDate, -15:MM/dd/yyyy}");
                Console.Write($"${outing.CostPerPerson, -17}");
                Console.Write($"${outing.TotalEventCost}");
            }
        }
        //Add outing to list
        public void AddOutingToList(Outing outing)
        {
            _outingRepo.Add(outing);
        }
        //Get all outings
        public List<Outing> GetAllOutings()
        {
            return _outingRepo;
        }
        //Get all outings of one type
        public List<Outing> GetOutingsByType(EventType eventType)
        {
            List<Outing> typeList = new List<Outing>();
            foreach (Outing outing in _outingRepo)
            {
                if (outing.EventType == eventType)
                {
                    typeList.Add(outing);
                }
            }
            return typeList;
        }
        //Calculate combined cost for all outings
        public decimal CalculateTotalCostForAllOutings()
        {
            decimal grandTotalCost = 0;
            foreach (Outing outing in _outingRepo)
            {
                grandTotalCost += outing.TotalEventCost;
            }
            Console.WriteLine($"Total cost for all outings: ${grandTotalCost}");
            return grandTotalCost;
        }
        //Calculate combined cost for all outings of one type
        public decimal CalculateTotalCostForOutingType(EventType eventType)
        {
            decimal outingTypeCost = 0;
            foreach (Outing outing in _outingRepo)
            {
                if (outing.EventType == eventType)
                {
                    outingTypeCost += outing.TotalEventCost;
                }
            }
            Console.WriteLine($"Total cost for all {eventType} outings: ${outingTypeCost}");
            return outingTypeCost;
        }
        //Calculate if repo is empty
        public bool IsEmpty()
        {
            if (_outingRepo.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
