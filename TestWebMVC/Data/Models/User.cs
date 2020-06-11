using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebMVC.Data.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Status { get; set; }

        public DateTime dt { get; set; }
    }
}
