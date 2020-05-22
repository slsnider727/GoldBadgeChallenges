using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double SafetyRating { get; set; }
        public double CostNew { get; set; }
        public int CarAge
        {
            get
            {
                int currentYear = Convert.ToInt32(DateTime.Now.Year);
                return currentYear - Year;
            }
        }
        public double CostToReplace
        {
            get
            {
                if (CarAge <= 1)
                {
                    return CostNew;
                }
                else if (CarAge <= 5)
                {
                    return CostNew * 0.7;
                }
                else if (CarAge < 10)
                {
                    return CostNew * 0.5;
                }
                else
                {
                    return CostNew * 0.2;
                }
            }
        }
    }
}
