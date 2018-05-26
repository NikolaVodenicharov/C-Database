using Forum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Client.Manager.Commands
{
    public class PostCommand : IExecutable
    {
        private const string SuccefullyPost = "Posted successfully.";
        private const string UnsuccefullyPost = "You are not logged.";

        private IPostService service;

        public PostCommand (IPostService service)
        {
            this.service = service;
        }

        public string Execute(params string[] arguments)
        {
            if (Session.User == null)
            {
                return UnsuccefullyPost;
            }

            string title = arguments[0];
            string content = arguments[1];
            string categoryName = arguments[2];
            int userId = Session.User.Id;

            service.Create(title, content, categoryName, userId);

            return SuccefullyPost;
        }
    }
}
