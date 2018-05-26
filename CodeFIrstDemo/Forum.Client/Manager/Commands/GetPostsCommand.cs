using Forum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Client.Manager.Commands
{
    public class GetPostsCommand : IExecutable
    {
        private const string UnsuccefullyPost = "You are not logged.";
        private IUserService service;

        public GetPostsCommand(IUserService service)
        {
            this.service = service;
        }

        public string Execute(params string[] arguments)
        {
            var posts = service.AllPosts();
            var sb = new StringBuilder();
            foreach (var entity in posts)
            {
                sb.AppendLine($"{entity.Id}. Title: {entity.Title} Content: {entity.Content} by {entity.Author.Username}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
