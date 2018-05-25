using Forum.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Client.Manager.Commands
{
    public class LoginCommand : IExecutable
    {
        private const string Message = "Logged succesfully.";

        private IUserService service;

        public LoginCommand(IUserService service)
        {
            this.service = service;
        }

        public string Execute(params string[] arguments)
        {
            var username = arguments[0];
            var password = arguments[1];

            var user = service.ByUsernameAndPassword(username, password);
            Session.User = user;

            return Message;
        }
    }
}
