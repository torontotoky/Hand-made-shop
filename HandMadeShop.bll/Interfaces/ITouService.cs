using HandMadeShop.bll.models;

namespace HandMadeShop.bll.Interfaces
{
    public interface ITouService
    {
        public Task<BToy> CreateToy(BToy bToy);
        public BToy UpdateToy(BToy bToy);
        public IEnumerable<BToy> GetToys();
        public BToy GetToy(int id);
        public void DeleteToy(int id);
    }
}
