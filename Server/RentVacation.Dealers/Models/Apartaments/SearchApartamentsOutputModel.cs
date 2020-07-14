using System.Collections.Generic;

namespace RentVacation.Dealers.Models.Apartaments
{
    public class SearchApartamentsOutputModel : ApartamentsOutputModel<ApartamentOutputModel>
    {
        public SearchApartamentsOutputModel(
            IEnumerable<ApartamentOutputModel> apartaments,
            int page,
            int totalPages)
            : base(apartaments, page, totalPages)
        {
        }
    }
}
