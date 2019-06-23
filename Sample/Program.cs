using System;
using TextReaderExtensions;

namespace Sample
{
    static class Program
    {
        static void Main()
        {
            Console.Write("Enter an integer value: ");
            Console.WriteLine($"You entered {Console.In.ReadInteger()}");
        }
    }
}
