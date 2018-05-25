using Forum.Client.Manager.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Client.Manager.CommandInterpreters
{
    public interface ICommandInterpreter
    {
        IExecutable Intepret(string commandName);
    }
}
