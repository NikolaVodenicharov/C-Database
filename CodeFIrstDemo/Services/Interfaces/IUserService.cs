using Forum.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Services.Interfaces
{
    public interface IUserService
    {
        User ById(int id);
        User ByUsername(string username);
        User ByUsernameAndPassword(string username, string password);
        User Create(string username, string password);
        void Delete(int id);
    }
}
