using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression2014Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your expression:");
            string exp = Console.ReadLine();
            Parser p = new Parser(exp);
            if (p.Parse())
                Console.WriteLine("The expression is correct");
            else
                Console.WriteLine("The expression is bad");
        }
    }
}
