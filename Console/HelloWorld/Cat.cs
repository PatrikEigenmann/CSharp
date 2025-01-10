using System;
using Samael;



namespace HelloWorld
{
    class Cat : Animal, ITest
    {
        public static new void Test()
        {
            Console.WriteLine("Cat Test");
        }

        public string GetVersion()
        {
            return VersionManager.GetInstance(this.GetType().Name, 0, 8).ToString();
        }

        public void Meow()
        {
            Console.WriteLine("The cat says: Meow!");
        }
    }
}
