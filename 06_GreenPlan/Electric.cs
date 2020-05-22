using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public enum Chance { High, Medium, Low, None }
    public class Electric : Vehicle
    {
        public Chance ChanceBatteryExplodesInCrash { get; set; }

        public Electric(
            string make,
            string model,
            int year,
            double safetyRating,
            double costNew,
            Chance chanceBatteryExplodesInCrash)
        {
            Make = make;
            Model = model;
            Year = year;
            SafetyRating = safetyRating;
            CostNew = costNew;
            ChanceBatteryExplodesInCrash = chanceBatteryExplodesInCrash;
        }
    }
}
