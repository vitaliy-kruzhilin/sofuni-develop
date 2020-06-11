using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebMVC.Data.Models
{
    public class Wallet
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Name { get; set; }

        public long Amount { get; set; }

        public int Status { get; set; }

        public DateTime dt { get; set; }

        public int Currency { get; set; }
    }
}
