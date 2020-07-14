using RentVacation.Common.Models;

namespace RentVacation.Dealers.Gateway.Models.Apartaments
{
    public class MineApartamentOutputModel : ApartamentOutputModel, IMapFrom<ApartamentOutputModel>
    {
        public int TotalViews { get; set; }
    }
}
