using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentVacation.Schedule.Data.Models
{
    public class RentedApartament
    {
        public int Id { get; set; }

        public bool HasInshurence { get; set; }

        public int ApartamentId { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
