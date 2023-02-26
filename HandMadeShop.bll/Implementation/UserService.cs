using AutoMapper;
using HandMadeShop.bll.Interfaces;
using HandMadeShop.bll.models;
using HandMadeShop.dal.context;
using HandMadeShop.dal.entites;

namespace HandMadeShop.bll.Implementation
{
    internal class UserService : IUserService
    {
        private readonly ApplicationContext db;
        private readonly IMapper mapper;
        public UserService(ApplicationContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<BUser> CreateUser(BUser bUser)
        {
            var newUser = await db.Users.AddAsync(this.mapper.Map<User>(bUser));
            return this.mapper.Map<BUser>(newUser);
        }

        public void DeleteUser(int id)
        {
            var user = db.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception($"Пользователь с таким {id} не найден");
            }
            db.Users.Remove(user);
        }

        public BUser GetUser(int id)
        {
            var user = db.Users.SingleOrDefault(x => x.Id == id);
            return this.mapper.Map<BUser>(user);
        }

        public IEnumerable<BUser> GetUsers()
        {
            return this.mapper.Map<IEnumerable<BUser>>(db.Users);
        }

        public BUser UpdateUser(BUser bUser)
        {
            var user = db.Users.SingleOrDefault(x => x.Id == bUser.Id);

            if (user == null)
            {
                throw new Exception($"Пользователь с таким {bUser.Id} не найден");
            }

            user.Password = bUser.Password;
            user.Email = bUser.Email;
            user.FirstName = bUser.FirstName;
            user.LastName = bUser.LastName;
            user.IsAdmin = bUser.IsAdmin;

            db.Users.Update(user);

            return bUser;
        }
    }
}
