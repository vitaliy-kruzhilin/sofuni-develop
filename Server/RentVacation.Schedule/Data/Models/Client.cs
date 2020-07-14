using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentVacation.Schedule.Data.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string PersonalId { get; set; }

        public int YearOfExperience { get; set; }

        public string UserId { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
