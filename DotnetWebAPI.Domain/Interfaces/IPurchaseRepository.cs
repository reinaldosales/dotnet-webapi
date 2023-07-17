using DotnetWebAPI.Models;

namespace DotnetWebAPI.Domain.Interfaces
{
    public interface IPurchaseRepository
    {
        public Task<Purchase> Save(Purchase purchase);
        public Task<Purchase> Update(Purchase purchase);
        public Task<IEnumerable<Purchase>> RecoverAllPurchases();
        public Task<Purchase> RecoverById(int id);
    }
}
