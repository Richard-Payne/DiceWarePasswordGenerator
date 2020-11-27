using System;
using DicewarePasswordGenerator;

namespace test
{
    public static class Program
    {
        public static void Main()
        {
            string password = PasswordGenerator.generate();
            Console.WriteLine("Hello World!");
        }
    }
}
