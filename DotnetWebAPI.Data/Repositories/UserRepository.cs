using DotnetWebAPI.Domain.Interfaces;
using DotnetWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetWebAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async Task<IEnumerable<User>> RecoverAllUsers()
            => await _appDbContext.User
            .AsNoTracking()
            .ToListAsync();

        public async Task<User> RecoverById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> RecoverByLogin(string name, string password) 
            => await _appDbContext.User
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Name == name);

        public async Task<User> Save(User user)
        {
            await _appDbContext.User.AddAsync(user);
            await _appDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
