namespace HandMadeShop.dal.entites
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Toy> Toys { get; set; } = new();
    }
}