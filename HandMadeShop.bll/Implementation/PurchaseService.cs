using AutoMapper;
using HandMadeShop.bll.Interfaces;
using HandMadeShop.bll.models;
using HandMadeShop.dal.context;
using HandMadeShop.dal.entites;

namespace HandMadeShop.bll.Implementation
{
    internal class PurchaseService : IPurchaseService
    {
        private readonly ApplicationContext db;
        private readonly IMapper mapper;

        public PurchaseService(ApplicationContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<BPurchase> CreatePurchase(BPurchase bPurchase)
        {
            var newPurchase = await db.Purchases.AddAsync(this.mapper.Map<Purchase>(bPurchase));
            db.SaveChanges();
            return this.mapper.Map<BPurchase>(newPurchase);

        }

        public void DeletePurchase(int id)
        {
            var purchase = db.Purchases.SingleOrDefault(x => x.Id == id);

            if (purchase == null)
            {
                throw new Exception($"Покупка с таким {id} не найдена");
            }

            db.Purchases.Remove(purchase);
            db.SaveChanges();
        }

        public BPurchase GetPurchase(int id)
        {
            var purchase = db.Purchases.SingleOrDefault(x => x.Id == id);
            return this.mapper.Map<BPurchase>(purchase);
        }

        public IEnumerable<BPurchase> GetPurchases()
        {
            return this.mapper.Map<IEnumerable<BPurchase>>(db.Purchases);
        }

        public BPurchase UpdatePurchase(BPurchase bPurchase)
        {
            var purchase = db.Purchases.SingleOrDefault(x => x.Id == bPurchase.Id);

            if (purchase == null)
            {
                throw new Exception($"Покупка с таким {purchase.Id} не найдена");
            }

            purchase.DateOfPurchase = bPurchase.DateOfPurchase;
            purchase.NumberOfPurchase = bPurchase.NumberOfPurchase;
            purchase.UserId = bPurchase.UserId;

            var toysIds = bPurchase.Toys.Select(p => p.Id);
            var toys = db.Toys.Where(p => toysIds.Contains(p.Id)).ToList();

            purchase.Toys = toys;

            db.Purchases.Update(purchase);
            db.SaveChanges();

            return bPurchase;
        }
    }
}
