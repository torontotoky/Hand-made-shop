using HandMadeShop.bll.models;

namespace HandMadeShop.bll.Interfaces
{
    public interface IMaterialService
    {
        public Task<BMaterial> CreateMaterial(BMaterial bMaterial);
        public BMaterial UpdateMaterial(BMaterial bMaterial);
        public IEnumerable<BMaterial> GetMaterials();
        public BMaterial GetMaterial(int id);
        public void DeleteMaterial(int id);
    }
}
