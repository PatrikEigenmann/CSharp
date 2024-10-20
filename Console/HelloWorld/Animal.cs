using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Animal : ITest
    {
        public static void Test()
        {
            Console.WriteLine("Animal Test");
        }

        public void Eat()
        {
            Console.WriteLine("Animal is eating!");
        }

        public void Sleep()
        {
            Console.WriteLine("Animal is sleeping!");
        }
    }
}
