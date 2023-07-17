using DotnetWebAPI.Models;
using DotnetWebAPI.ViewModels;

namespace DotnetWebAPI.Application.Interfaces
{
    public interface IPurchaseService
    {
        public Task<IEnumerable<Purchase>> RecoverAllPurchases();
        public Task<User> CreatePurchase(CreatePurchaseModel createPurchaseModel);
        public Task<User> RecoverPurchaseById(int id);
    }
}
