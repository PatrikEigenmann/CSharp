using System;
using Samael;

namespace HelloWorld
{
    public class Dog : Animal, IVersionable, ITest
    {
        public string GetVersion()
        {
            return VersionManager.GetInstance(this.GetType().Name, 0, 3).ToString();
        }

        public void Bark()
        {
            Console.WriteLine("The Dog says: Woof!");
        }

        public static new void Test()
        {
            Console.WriteLine("Dog Test");
        }
    }
}
