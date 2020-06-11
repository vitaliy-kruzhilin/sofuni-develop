using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebMVC.Data.Models
{
    public class WalletHistory
    {
        public long Id { get; set; }

        public long WalletId { get; set; }

        public string Target { get; set; }

        public DateTime dt { get; set; }

        public long Amount { get; set; }

        public int Currency { get; set; }
    }
}
