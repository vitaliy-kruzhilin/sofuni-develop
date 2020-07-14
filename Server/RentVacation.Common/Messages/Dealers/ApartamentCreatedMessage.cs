using System;
using System.Collections.Generic;
using System.Text;

namespace RentVacation.Common.Messages.Dealers
{
    public class ApartamentCreatedMessage
    {
        public int ApartamentId { get; set; }

        public string Information { get; set; }
    }
}
