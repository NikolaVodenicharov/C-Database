using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Data;
using Forum.Models;
using Forum.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Forum.Services.UserServices
{
    public class UserService : AbstractService, IUserService
    {
        public UserService(ForumDbContext context) : base(context) {}

        private User ById(int id)
        {
            var user = this.GetContext.Users.Find(id);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid user id");
            }

            return user;
        }

        public User ByUsername(string username)
        {
            User user = this.ByUsernameWithoutChecking(username);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid username");
            }

            return user;
        }
        private User ByUsernameWithoutChecking(string username)
        {
            User user = this.GetContext
                .Users
                .SingleOrDefault(u => u.Username == username);

            return user;
        }

        public User ByUsernameAndPassword(string username, string password)
        {
            User user = 
                this.GetContext
                .Users
                .SingleOrDefault(u => 
                    u.Username == username &&
                    u.Password == password);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid username or password");
            }

            return user;
        }

        public User Create(string username, string password)
        {
            if (this.IsUsernameBusy(username))
            {
                throw new InvalidOperationException("Username is busy.");
            }

            return this.CreateWithoutChecking(username, password);
        }
        private bool IsUsernameBusy(string username)
        {
            if (this.ByUsernameWithoutChecking(username) == null)
            {
                return false;
            }

            return true;
        }
        private User CreateWithoutChecking(string username, string password)
        {
            User user = new User(username, password);
            this.GetContext.Users.Add(user);
            this.GetContext.SaveChanges();

            return user;
        }

        public void Delete(int id)
        {
            User user = this.GetContext.Users.Find(id);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid user");
            }

            this.GetContext.Users.Remove(user);
            this.GetContext.SaveChanges();
        }

        public IEnumerable<Post> AllPosts()
        {
            var posts =
                this.GetContext
                .Posts
                .Include(p => p.Author)
                .ToArray();

            return posts;
        }
    }
}
