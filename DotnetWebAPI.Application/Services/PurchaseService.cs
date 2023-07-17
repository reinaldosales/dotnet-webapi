using DotnetWebAPI.Application.Interfaces;
using DotnetWebAPI.Domain.Interfaces;
using DotnetWebAPI.Models;
using DotnetWebAPI.ViewModels;

namespace DotnetWebAPI.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
            => _purchaseRepository = purchaseRepository;

        public Task<User> CreatePurchase(CreatePurchaseModel createPurchaseModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Purchase>> RecoverAllPurchases()
        {
            throw new NotImplementedException();
        }

        public Task<User> RecoverPurchaseById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
