using AutoMapper;
using HandMadeShop.bll.Interfaces;
using HandMadeShop.bll.models;
using HandMadeShop.dal.context;
using HandMadeShop.dal.entites;

namespace HandMadeShop.bll.Implementation
{
    public class MaterialService : IMaterialService
    {
        private readonly ApplicationContext db;
        private readonly IMapper mapper;

        public MaterialService(ApplicationContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<BMaterial> CreateMaterial(BMaterial bMaterial)
        {
            var newMaterial = await db.Materials.AddAsync(this.mapper.Map<Material>(bMaterial));
            db.SaveChanges();
            return this.mapper.Map<BMaterial>(newMaterial);
        }

        public void DeleteMaterial(int id)
        {
            var material = db.Materials.SingleOrDefault(x => x.Id == id);

            if (material == null)
            {
                throw new Exception($"Материал с таким {id} не найден");
            }

            db.Materials.Remove(material);
            db.SaveChanges();
        }

        public BMaterial GetMaterial(int id)
        {
            var material = db.Materials.SingleOrDefault(x => x.Id == id);
            return this.mapper.Map<BMaterial>(material);
        }

        public IEnumerable<BMaterial> GetMaterials()
        {
            return this.mapper.Map<IEnumerable<BMaterial>>(db.Materials);
        }

        public BMaterial UpdateMaterial(BMaterial bMaterial)
        {
            var material = db.Materials.SingleOrDefault(x => x.Id == bMaterial.Id);

            if (material == null)
            {
                throw new Exception($"Материал с таким {bMaterial.Id} не найден");
            }

            material.Name = bMaterial.Name;

            db.Materials.Update(material);
            db.SaveChanges();

            return bMaterial;
        }
    }
}
