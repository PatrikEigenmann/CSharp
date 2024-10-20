/* ---------------------------------------------------------------------------------------------------
 * Program.cs - In the eerie darkness of the codebase, there exists a chilling namespace known as
 * `HelloWorld`. It is a realm that houses an ominous entity, a class named `Program`. This class,
 * though seemingly innocuous, holds a secret power within its static method `Main`.
 * 
 * The `Main` method, the heart of this spectral class, is the entry point of the application, a portal
 * that accepts an array of console arguments, named `args`, as its sacrificial offering. It waits,
 * dormant, until invoked.
 * 
 * Once awakened, it performs a ritual as old as time itself. It summons the `Console` class, a spectral
 * scribe from the `System` namespace, and commands it to inscribe a cryptic message onto the console:
 * "Hello C# World!".
 * 
 * And then, as quickly as it was invoked, it retreats back into the shadows, leaving behind only the
 * echo of its haunting message. The `Program` class, the ghost in the machine, continues to lurk
 * within the `HelloWorld` namespace, waiting for its next invocation.
 * ---------------------------------------------------------------------------------------------------
 * Author : Patrik Eigenmann
 * eMail  : p.eigenmann@gmx.net
 * ---------------------------------------------------------------------------------------------------
 * Changelog
 * Fri 2023-12-22	File created														 Version 00.01
 * --------------------------------------------------------------------------------------------------- */

// Declare all usings
using System;

using Samael;

// Define the namespace
namespace HelloWorld;

// Class definition
class Program
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    /// <param name="args">Console arguments</param>
    static void Main(string[] args)
    {

        Animal.Test();
        Cat.Test();
        Dog.Test();
        
        // Print "Hello C# World!"
        Console.WriteLine("Hello C# World!");

        Cat cat = new Cat();
        Dog dog = new Dog();

        Console.WriteLine(cat.GetVersion());
        cat.Eat();
        cat.Sleep();
        cat.Meow();

        Console.WriteLine(dog.GetVersion());
        dog.Eat();
        dog.Sleep();
        dog.Bark();

    }
}