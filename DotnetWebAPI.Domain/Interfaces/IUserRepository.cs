using DotnetWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWebAPI.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> Save(User user);
        public Task<User> Update(User user);
        public Task<IEnumerable<User>> RecoverAllUsers();
        public Task<User> RecoverById(int id);
        public Task<User> RecoverByLogin(string name, string password);
    }
}
