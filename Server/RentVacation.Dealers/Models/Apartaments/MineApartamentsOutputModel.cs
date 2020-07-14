using System.Collections.Generic;

namespace RentVacation.Dealers.Models.Apartaments
{
    public class MineApartamentsOutputModel : ApartamentsOutputModel<MineApartamentOutputModel>
    {
        public MineApartamentsOutputModel(
            IEnumerable<MineApartamentOutputModel> apartaments,
            int page,
            int totalPages)
            : base(apartaments, page, totalPages)
        {
        }
    }
}
