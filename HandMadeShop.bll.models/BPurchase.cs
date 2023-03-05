namespace HandMadeShop.bll.models
{
    public class BPurchase
    {
        public int Id { get; set; }
        public int NumberOfPurchase { get; set; } // Номер покупки
        public int UserId { get; set; }
        public List<BToy> Toys { get; set; } = new();
        public DateTime DateOfPurchase { get; set; } // Дата покупки
    }
}
