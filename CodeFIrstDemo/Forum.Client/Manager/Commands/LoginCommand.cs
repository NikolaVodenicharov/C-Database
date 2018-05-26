namespace Forum.Client.Manager.Commands
{
    using Forum.Services.Interfaces;

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
            if (user == null)
            {
                return "Invalid username or password";
            }

            Session.User = user;

            return Message;
        }
    }
}
