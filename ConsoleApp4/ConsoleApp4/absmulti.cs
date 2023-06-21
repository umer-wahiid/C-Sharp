using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class absmulti : @abstract
    {
        public override int cal(int a, int b)
        {
            return a * b;
        }

        public override string wel(string wel)
        {
            throw new NotImplementedException();
        }
    }
}
