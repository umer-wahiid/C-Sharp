using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class polymorphism
    {

        public string data(string n)
        {
            return "Welcome" + "\nName: " + n;
        }

        public string data(string n,string fn)
        {
            return "Welcome" + "\nName: " + n + "\nFather Name: "+fn;
        }

        public string data(string n, string fn, string age)
        {
            return "Welcome" + "\nName: " + n + "\nFather Name: " + fn+ "\nAge: "+age;
        }

        public string data(string n, string fn, string age,string num)
        {
            return "Welcome" + "\nName: " + n + "\nFather Name: " + fn + "\nAge: " + age+ "\nPhone: "+ num;
        }

        public string data(string n, string fn, string age, string num,string add)
        {
            return "Welcome" + "\nName: " + n + "\nFather Name: " + fn + "\nAge: " + age + "\nPhone: " + num+ "\nAddress: " + add ;
        }

        public void add(string num1,int num2)
        {
            Console.WriteLine(num1+num2);
        }

        
        public virtual double calc(double num1, double num2)
        {
            return num1 + num2;
        }
        


        public virtual double calc(double num1)
        {
            return num1 * num1;
        }
    }
}
