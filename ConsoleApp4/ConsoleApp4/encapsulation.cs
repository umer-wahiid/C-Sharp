using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class encapsulation
    {
        private string n;
        public string propfunc
        {
            set { n = value; }
            get { return n; }
        }

        private int age;
        public int propfunc2
        {
            set;
            get;
        }

        //without propert pethod

        public void propfunc3(string nn, int ageage)
        {
            n = nn;
            age = ageage;
            Console.WriteLine(n + " is " + age + " years old");
        }

        private string ag;
        public string prop(string nn, string ageage)
        {
            string n = nn;
            string ag = ageage;
            return n + " is " + ag + " years old";
        }

        public encapsulation(string nn, string agag)
        {
            string n = nn;
            string ag = agag;
            Console.WriteLine(n + " is " + ag + " years old");
        }

    }
}
