using Hospital.Data;
using System;
using Hospital.DatabaseInitializer;

namespace Hospital.App
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Initializer.ResetDatabase();

            Console.WriteLine("Hi");
        }
    }
}
