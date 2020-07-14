using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentVacation.Schedule.Data.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }
    }
}
