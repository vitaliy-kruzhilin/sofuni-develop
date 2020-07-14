using AutoMapper;
using RentVacation.Dealers.Data.Models;
using RentVacation.Dealers.Models.Dealers;

namespace RentVacation.Dealers.Models.Apartaments
{
    public class ApartamentDetailsOutputModel : ApartamentOutputModel
    {
        public bool HasClimateControl { get; private set; }

        public int NumberOfSeats { get; private set; }

        public string TransmissionType { get; private set; }

        public DealerOutputModel Dealer { get; set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Apartament, ApartamentDetailsOutputModel>()
                .IncludeBase<Apartament, ApartamentOutputModel>()
                .ForMember(c => c.HasClimateControl, cfg => cfg
                    .MapFrom(c => c.Options.HasClimateControl))
                .ForMember(c => c.NumberOfSeats, cfg => cfg
                    .MapFrom(c => c.Options.NumberOfBeds))
                .ForMember(c => c.TransmissionType, cfg => cfg
                    .MapFrom(c => c.Options.Floor))
                .ForMember(c => c.Dealer, cfg => cfg
                    .MapFrom(c => c.Dealer));
    }
}
