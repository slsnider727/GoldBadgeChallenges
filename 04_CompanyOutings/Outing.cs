using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyOutings
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert, None }
    public class Outing
    {
        public EventType EventType { get; set; }
        public int AttendeeCount { get; set; }
        public DateTime EventDate { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalEventCost
        {
            get
            {
                return AttendeeCount * CostPerPerson;
            }
        }

        public Outing (
            EventType eventType,
            int attendeeCount,
            DateTime eventDate,
            decimal costPerPerson
            )
        {
            EventType = eventType;
            AttendeeCount = attendeeCount;
            EventDate = eventDate;
            CostPerPerson = costPerPerson;
        }
    }
}
