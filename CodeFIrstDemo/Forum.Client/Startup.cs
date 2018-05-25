using Forum.Client.IO;
using Forum.Client.Manager;
using Forum.Client.Manager.CommandInterpreters;
using Forum.Data;
using Forum.DatabaseInitializer;
using Forum.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Forum.Client
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var interpreter = new CommandInterpreter(serviceProvider);

            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Engine(serviceProvider, interpreter, reader, writer);

            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<ForumDbContext>(options => options.UseSqlServer(Connection.ConnectionString));
            serviceCollection.AddTransient<IUserService, UserService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
