using RentVacation.Common.Models;

namespace RentVacation.Admin.Models.Dealers
{
    public class DealerInputModel : IMapFrom<DealerFormModel>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
