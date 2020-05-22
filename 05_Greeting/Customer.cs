using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greeting
{
    public enum CustomerType { Potential, Current, Past, None }
    public class Customer
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public CustomerType CustomerType { get; set; }
        public string Email
        {
            get
            {
                if (CustomerType == CustomerType.Potential)
                {
                    return "We currently have the lowest rates on Helicopter Insurance!";
                }
                else if (CustomerType == CustomerType.Current)
                {
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                }
                else if (CustomerType == CustomerType.Past)
                {
                    return "It's been a long time since we've heard from you. We want you back!";
                }
                else
                {
                    return null;
                }
            }
        }

        public Customer(
            string lastName,
            string firstName,
            CustomerType customerType
            )
        {
            LastName = lastName;
            FirstName = firstName;
            CustomerType = customerType;
        }
    }
}
