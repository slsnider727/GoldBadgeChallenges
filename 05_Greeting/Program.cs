using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greeting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 125;
            CustomerUI UI = new CustomerUI();
            UI.Run();
        }
    }
}
