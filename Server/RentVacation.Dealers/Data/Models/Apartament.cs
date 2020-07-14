namespace RentVacation.Dealers.Data.Models
{
    public class Apartament
    {
        public int Id { get; set; }

        public string Information { get; set; }

        public string ImageUrl { get; set; }

        public decimal PricePerDay { get; set; }

        public Options Options { get; set; }

        public bool IsAvailable { get; set; }

        public int DealerId { get; set; }

        public Dealer Dealer { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
