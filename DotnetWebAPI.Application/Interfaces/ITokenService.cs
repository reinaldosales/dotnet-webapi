using DotnetWebAPI.Models;

namespace DotnetWebAPI.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
