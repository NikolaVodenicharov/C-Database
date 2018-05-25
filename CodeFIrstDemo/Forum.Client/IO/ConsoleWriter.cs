using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Client.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
