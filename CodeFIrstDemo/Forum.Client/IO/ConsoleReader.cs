using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Client.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string line = Console.ReadLine();
            return line;
        }
    }
}
