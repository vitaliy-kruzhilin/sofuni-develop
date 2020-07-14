using RentVacation.Common.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentVacation.Admin.Models.Dealers
{
    public class DealerFormModel : IMapFrom<DealerDetailsOutputModel>
    {
        [Required]
        [DisplayName("Dealer Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
