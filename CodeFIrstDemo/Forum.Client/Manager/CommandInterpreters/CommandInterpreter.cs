using Forum.Client.Manager.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Forum.Client.Manager.CommandInterpreters
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable Intepret(string commandName)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().ToArray();

            var iExecutableTypes = types
                .Where(t => t
                    .GetInterfaces()
                    .Contains(typeof(IExecutable)))
                .ToArray();

            var name = $"{commandName}Command";
            var type = iExecutableTypes
                .FirstOrDefault(t => t
                    .Name
                    .Equals(name, StringComparison.OrdinalIgnoreCase));
            if (type == null)
            {
                throw new InvalidOperationException("Invalid command.");
            }

            var constructor = type.GetConstructors().First();
            var parameters = constructor
                .GetParameters()
                .Select(pi => pi.ParameterType)
                .ToArray();
            var services = parameters
                .Select(p => serviceProvider.GetService(p))
                .ToArray();

            var command = (IExecutable) constructor.Invoke(services);


            return command;
        }
    }
}
