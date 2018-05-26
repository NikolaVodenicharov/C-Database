using System;
using System.Linq;
using Forum.Data;
using Forum.Models;
using Forum.Services.Interfaces;

namespace Forum.Services.UserServices
{
    public class UserService : AbstractService, IUserService
    {
        public UserService(ForumDbContext context) 
            : base(context)
        {
        }

        public User ById(int id)
        {
            User user = this.GetContext.Users.Find(id);

            return user;
        }
        public User ByUsername(string username)
        {
            User user =
                this.GetContext
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

            return user;
        }
        public User Create(string username, string password)
        {
            // check is that username already exist. We can put unique constraint for username in database.
            User user = new User(username, password);
            this.GetContext.Users.Add(user);
            this.GetContext.SaveChanges();

            return user;
        }
        public void Delete(int id)
        {
            User user = this.GetContext.Users.Find(id);
            this.GetContext.Users.Remove(user);
            this.GetContext.SaveChanges();
        }
    }
}
