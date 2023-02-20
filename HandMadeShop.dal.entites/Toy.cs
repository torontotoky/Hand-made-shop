namespace HandMadeShop.dal.entites
{
    public class Toy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Size { get; set; }
        public List<Material> Materials { get; set; } = new();
    }
}