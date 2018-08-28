using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Part_2
{
    class Program
    {
        private 

        static void Main(string[] args)
        {
            int val1 = 0;
            int val2 = 0;

            Console.WriteLine("Please enter the requested values.\r\n");

            Console.Write("First Number  : ");
            int.TryParse(Console.ReadLine(), out val1);

            Console.Write("Second Number : ");
            int.TryParse(Console.ReadLine(), out val2);

            Console.WriteLine(String.Format("{0} + {1} = {2}", val1, val2, (val1 + val2)));
            Console.WriteLine(String.Format("{0} - {1} = {2}", val1, val2, (val1 - val2)));
            Console.WriteLine(String.Format("{0} * {1} = {2}", val1, val2, (val1 * val2)));
            Console.WriteLine(String.Format("{0} / {1} = {2}", val1, val2, (val1 / val2)));
            Console.WriteLine(String.Format("{0} % {1} = {2}", val1, val2, (val1 % val2)));

            Console.WriteLine(String.Format("Is {0} less than {1}: {2}", val1, val2, (val1 < val2 ? "True" : "False")));
            Console.WriteLine(String.Format("Is {0} greater than {1}: {2}", val1, val2, (val1 > val2 ? "True" : "False")));
            Console.WriteLine(String.Format("Is {0} equal to {1}: {2}", val1, val2, (val1 == val2 ? "True" : "False")));

            Console.Write("\r\nPress Enter To Close.");
            Console.Read();
        }
    }
}
