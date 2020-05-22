using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public class Hybrid : Vehicle
    {
        public Hybrid (
            string make,
            string model,
            int year,
            double safetyRating,
            double costNew)
        {
            Make = make;
            Model = model;
            Year = year;
            SafetyRating = safetyRating;
            CostNew = costNew;
        }
    }
}
