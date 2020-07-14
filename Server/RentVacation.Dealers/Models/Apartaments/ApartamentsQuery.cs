namespace RentVacation.Dealers.Models.Apartaments
{
    public class ApartamentsQuery
    {
        public int? Category { get; set; }

        public string Dealer { get; set; }

        public decimal? MinPricePerDay { get; set; }

        public decimal? MaxPricePerDay { get; set; }

        public string SortBy { get; set; }

        public string Order { get; set; }

        public int Page { get; set; } = 1;
    }
}
