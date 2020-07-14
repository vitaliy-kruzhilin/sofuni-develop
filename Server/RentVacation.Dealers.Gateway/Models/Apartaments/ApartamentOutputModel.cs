namespace RentVacation.Dealers.Gateway.Models.Apartaments
{
    public class ApartamentOutputModel
    {
        public int Id { get; set; }

        public string Information { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public decimal PricePerDay { get; set; }

        public bool IsAvailable { get; private set; }
    }
}
