using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Client.Manager.Commands
{
    public class LogoutCommand : IExecutable
    {
        private const string SuccesfullyLogout = "Logout succesfully";
        private const string UnsuccefullyLogout = "You are not logged.";

        public string Execute(params string[] arguments)
        {
            if (Session.User == null)
            {
                return UnsuccefullyLogout;
            }

            Session.User = null;
            return SuccesfullyLogout;
        }
    }
}
