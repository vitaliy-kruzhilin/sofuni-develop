using System.Collections.Generic;

namespace RentVacation.Dealers.Models.Apartaments
{
    public abstract class ApartamentsOutputModel<TApartamentOutputModel>
    {
        protected ApartamentsOutputModel(
            IEnumerable<TApartamentOutputModel> apartaments,
            int page,
            int totalPages)
        {
            this.Apartaments = apartaments;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TApartamentOutputModel> Apartaments { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
