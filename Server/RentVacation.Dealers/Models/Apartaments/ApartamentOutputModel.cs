using AutoMapper;
using RentVacation.Dealers.Data.Models;

namespace RentVacation.Dealers.Models.Apartaments
{

    public class ApartamentOutputModel : IMapFrom<Apartament>
    {
        public int Id { get; set; }

        public string Information { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; } 

        public decimal PricePerDay { get; set; }

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Apartament, ApartamentOutputModel>()
                .ForMember(ad => ad.Category, cfg => cfg
                    .MapFrom(ad => ad.Category.Name));
    }
}
