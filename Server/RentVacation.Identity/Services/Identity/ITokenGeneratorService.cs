using RentVacation.Identity.Data.Models;
using System.Collections.Generic;

namespace RentVacation.Identity.Services.Identity
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(User user, IEnumerable<string> roles = null);
    }
}
