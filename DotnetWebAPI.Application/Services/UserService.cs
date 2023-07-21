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
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<User>> RecoverAllUsers()
        {
            return await _userRepository.RecoverAllUsers();
        }

        public async Task<User> CreateUser(CreateUserModel createUserModel)
        {
            var user = new User(
                createUserModel.Name,
                new Email(createUserModel.Email),
                "default",
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

        public async Task<string> Login(string name, string password)
        {
            var user = await _userRepository.RecoverByLogin(name, password);

            if (user is null)
                throw new NullReferenceException("User not found");

            return _tokenService.GenerateToken(user);
        }
    }
}
