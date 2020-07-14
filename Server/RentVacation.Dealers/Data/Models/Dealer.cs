using System.Collections.Generic;

namespace RentVacation.Dealers.Data.Models
{
    public class Dealer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public ICollection<Apartament> Apartaments { get; set; } = new List<Apartament>();
    }
}