using RentVacation.Common.Models;
using RentVacation.Identity.Data.Models;
using System.ComponentModel.DataAnnotations;

using static RentVacation.Identity.Data.DataConstants.Identity;

namespace RentVacation.Identity.Models.Identity
{
    public class UserInputModel: IMapFrom<User>
    {
        [EmailAddress]
        [Required]
        [MinLength(MinEmailLength)]
        [MaxLength(MaxEmailLength)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
