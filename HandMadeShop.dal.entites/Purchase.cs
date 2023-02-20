namespace HandMadeShop.dal.entites
{
    public class Purchase
    {
        public int Id { get; set; }
        public int NumberOfPurchase { get; set; } // Номер покупки
        public int UserId { get; set; }
        public User? User { get; set; }

        public List<Toy> Toys { get; set; } = new();

        public DateTime DateOfPurchase { get; set; } // Дата покупки
    }
}