using DotnetWebAPI.Application.Interfaces;
using DotnetWebAPI.Domain.Interfaces;
using DotnetWebAPI.Models;
using DotnetWebAPI.ObjectValues;
using DotnetWebAPI.ViewModels;

namespace DotnetWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
            => _userRepository = userRepository;

        public async Task<IEnumerable<User>> RecoverAllUsers()
        {
            return await _userRepository.RecoverAllUsers();
        }

        public async Task<User> CreateUser(CreateUserModel createUserModel)
        {
            var user = new User(
                createUserModel.Name,
                new Email(createUserModel.Email),
                DateTime.Now,
                DateTime.Now,
                null);

            return await _userRepository.Save(user);
        }

        public async Task<User> RecoverUserById(int id)
        {
            return await _userRepository.RecoverById(id);
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = await _userRepository.RecoverById(id) ?? throw new ArgumentNullException("Deleted user or invalid");

            user.DeletedAt = DateTime.Now;

            return await _userRepository.Update(user);
        }
    }
}
