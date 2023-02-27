using AutoMapper;
using HandMadeShop.bll.Interfaces;
using HandMadeShop.bll.models;
using HandMadeShop.dal.context;
using HandMadeShop.dal.entites;

namespace HandMadeShop.bll.Implementation
{
    public class ToyService : ITouService
    {
        private readonly ApplicationContext db;
        private readonly IMapper mapper;

        public ToyService(ApplicationContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<BToy> CreateToy(BToy bToy)
        {
            var newToy = await db.Toys.AddAsync(this.mapper.Map<Toy>(bToy));
            db.SaveChanges();
            return this.mapper.Map<BToy>(newToy);
        }

        public void DeleteToy(int id)
        {
            var toy = db.Toys.SingleOrDefault(x => x.Id == id);

            if (toy == null)
            {
                throw new Exception($"Игрушка с таким {id} не найдена");
            }

            db.Toys.Remove(toy);

            db.SaveChanges();
        }

        public BToy GetToy(int id)
        {
            var toy = db.Toys.SingleOrDefault(x => x.Id == id);
            return this.mapper.Map<BToy>(toy);
        }

        public IEnumerable<BToy> GetToys()
        {
            return this.mapper.Map<IEnumerable<BToy>>(db.Toys);
        }

        public BToy UpdateToy(BToy bToy)
        {
            var toy = db.Toys.SingleOrDefault(x => x.Id == bToy.Id);

            if (toy == null)
            {
                throw new Exception($"Игрушка с таким {bToy.Id} не найдена");
            }

            toy.Size = bToy.Size;
            toy.Discription = bToy.Discription;
            toy.Name = bToy.Name;

            var materialsIds = bToy.Materials.Select(m => m.Id); //Взяли id, которые пришли с bToy
            var materials = db.Materials.Where(m => materialsIds.Contains(m.Id)).ToList(); // Получили список id из таблицы мариалов бд, которые совпали с bToy

            toy.Materials = materials;

            db.Toys.Update(toy);
            db.SaveChanges();

            return bToy;
        }
    }
}
