using System.Linq;
using AutoMapper;
using RentVacation.Common.Models;
using RentVacation.Dealers.Data.Models;

namespace RentVacation.Dealers.Models.Categories
{
    public class CategoryOutputModel : IMapFrom<Category>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public int TotalApartaments { get; set; }

        public void Mapping(Profile profile)
            => profile
                .CreateMap<Category, CategoryOutputModel>()
                .ForMember(c => c.TotalApartaments, cfg => cfg
                    .MapFrom(c => c.Apartaments.Count()));
    }
}

