using AutoMapper;
using RentVacation.Dealers.Data.Models;

namespace RentVacation.Dealers.Models.Apartaments
{
    public class MineApartamentOutputModel : ApartamentOutputModel
    {
        public bool IsAvailable { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Apartament, MineApartamentOutputModel>()
                .IncludeBase<Apartament, ApartamentOutputModel>();
    }
}
