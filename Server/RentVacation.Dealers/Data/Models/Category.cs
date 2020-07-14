using System.Collections.Generic;

namespace RentVacation.Dealers.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Apartament> Apartaments { get; set; } = new List<Apartament>();
    }
}
