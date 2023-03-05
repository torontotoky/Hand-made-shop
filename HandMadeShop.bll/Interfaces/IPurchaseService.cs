using HandMadeShop.bll.models;

namespace HandMadeShop.bll.Interfaces
{
    internal interface IPurchaseService
    {
        public Task<BPurchase> CreatePurchase(BPurchase bPurchase);
        public BPurchase UpdatePurchase(BPurchase bPurchase);
        public IEnumerable<BPurchase> GetPurchases();
        public BPurchase GetPurchase(int id);
        public void DeletePurchase(int id);
    }
}
