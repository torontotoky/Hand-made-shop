using HandMadeShop.bll.models;

namespace HandMadeShop.bll.Interfaces
{
    public interface IUserService
    {
        public Task<BUser> CreateUser(BUser bUser);
        public BUser UpdateUser(BUser bUser);
        public IEnumerable<BUser> GetUsers();
        public BUser GetUser(int id);
        public void DeleteUser(int id);
    }
}
