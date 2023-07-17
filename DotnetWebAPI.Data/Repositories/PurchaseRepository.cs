using DotnetWebAPI.Domain.Interfaces;
using DotnetWebAPI.Models;

namespace DotnetWebAPI.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly AppDbContext _appDbContext;

        public PurchaseRepository(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public Task<IEnumerable<Purchase>> RecoverAllPurchases()
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> RecoverById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> Save(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> Update(Purchase purchase)
        {
            throw new NotImplementedException();
        }
    }
}
