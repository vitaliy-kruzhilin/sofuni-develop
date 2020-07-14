using RentVacation.Dealers.Data.Models;

namespace RentVacation.Dealers.Models.Dealers
{
    public class DealerOutputModel : IMapFrom<Dealer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
