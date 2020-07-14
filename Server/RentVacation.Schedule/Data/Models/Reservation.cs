using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentVacation.Schedule.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string ClientId { get; set; }

        public Client Client { get; set; }

        public int RentedApartamentId { get; set; }

        public RentedApartament RentedApartament { get; set; }
    }
}
