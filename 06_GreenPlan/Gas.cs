using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public class Gas : Vehicle
    {
        public bool IsUsedForTowing { get; set; }

        public Gas(
            string make,
            string model,
            int year,
            double safetyRating,
            double costNew,
            bool isUsedForTowing)
        {
            Make = make;
            Model = model;
            Year = year;
            SafetyRating = safetyRating;
            CostNew = costNew;
            IsUsedForTowing = isUsedForTowing;
        }
    }
}
