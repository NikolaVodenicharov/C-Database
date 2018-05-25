using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Client.Manager.Commands
{
    public interface IExecutable
    {
        string Execute(params string[] arguments);
    }
}
