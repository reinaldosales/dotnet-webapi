using DotnetWebAPI.Models;
using DotnetWebAPI.ObjectValues;
using DotnetWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWebAPI.Application.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> RecoverAllUsers();
        public Task<User> CreateUser(CreateUserModel createUserModel);
        public Task<User> RecoverUserById(int id);
        public Task<User> DeleteUser(int id);
        public Task<string> Login(string name, string password);
    }
}
