using System.ComponentModel.DataAnnotations;

using static RentVacation.Common.Data.DataConstants.Common;
using static RentVacation.Dealers.Data.DataConstants.Dealer;

namespace RentVacation.Dealers.Models.Dealers
{
    public class CreateDealerInputModel
    {
        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(MinPhoneNumberLength)]
        [MaxLength(MaxPhoneNumberLength)]
        [RegularExpression(PhoneNumberRegularExpression)]
        public string PhoneNumber { get; set; }
    }
}
