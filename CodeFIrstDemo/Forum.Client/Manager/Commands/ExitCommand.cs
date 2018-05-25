using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Client.Manager.Commands
{
    public class ExitCommand : IExecutable
    {
        public string Execute(params string[] arguments)
        {
            Environment.Exit(0);

            return null;
        }
    }
}
