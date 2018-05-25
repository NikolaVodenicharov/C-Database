using Forum.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Client.Manager.Commands
{
    public class RegisterCommand : IExecutable
    {
        private const string Message = "User created succesfully";

        private IUserService service;

        public RegisterCommand(IUserService service)
        {
            this.service = service;
        }

        public string Execute(params string[] arguments)
        {
            var username = arguments[0];
            var password = arguments[1];

            var user = service.Create(username, password);

            return Message;
        }
    }
}
