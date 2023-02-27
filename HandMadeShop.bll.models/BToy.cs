namespace HandMadeShop.bll.models
{
    public class BToy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Size { get; set; }
        public List<BMaterial> Materials { get; set; } = new();
    }
}
