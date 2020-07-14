using System.Linq;
using AutoMapper;
using RentVacation.Dealers.Data.Models;

namespace RentVacation.Dealers.Models.Dealers
{
    public class DealerDetailsOutputModel : DealerOutputModel
    {
        public int TotalApartaments { get; private set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Dealer, DealerDetailsOutputModel>()
                .IncludeBase<Dealer, DealerOutputModel>()
                .ForMember(d => d.TotalApartaments, cfg => cfg
                    .MapFrom(d => d.Apartaments.Count()));
    }
}
