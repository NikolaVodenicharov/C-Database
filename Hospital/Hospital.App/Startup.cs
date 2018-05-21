using Hospital.Data;
using System;
using Hospital.DatabaseInitializer;

namespace Hospital.App
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            using (var db = new HospitalDbContext())
            {
                Initializer.ResetDatabase();
            }

            Console.WriteLine("Hi");
        }
    }
}
