using Forum.Client.IO;
using Forum.Client.Manager.CommandInterpreters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Client.Manager
{
    public class Engine : IRunnable
    {
        IServiceProvider serviceProvider;
        ICommandInterpreter interpreter;
        IReader reader;
        IWriter writer;

        public Engine (IServiceProvider serviceProvider, ICommandInterpreter interpreter, IReader reader, IWriter writer)
        {
            this.serviceProvider = serviceProvider;
            this.interpreter = interpreter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                writer.WriteLine("Enter a command.");
                var line = reader.ReadLine();
                var splitLine = line.Split(' ');
       
                try
                {
                    var commandName = splitLine[0];
                    var command = interpreter.Intepret(commandName);

                    var commandArguments = splitLine.Skip(1).ToArray();
                    var result = command.Execute(commandArguments);

                    writer.WriteLine(result);
                }
                catch (InvalidOperationException e)
                {
                    writer.WriteLine(e.Message);
                }
            }
        }
    }
}
