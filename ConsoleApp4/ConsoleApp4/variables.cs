using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class variables: Class1
    {
        public variables()
        {
            Console.WriteLine("Value Of Constructor....No Need To Call it");
        }
        public string pub = "public variable";
        private string prvt = "private variable";
        internal int intr = 22;
        internal protected string intrpro = "internal protected variable";
        public void abc()
        {
            Console.WriteLine("Addition");
            Console.WriteLine(num1 + num2 - num3);
        }
        public static void xyz()
        {
            Console.WriteLine("Result Of Static Function");
        }
    }
}
