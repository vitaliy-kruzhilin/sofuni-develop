using System.ComponentModel.DataAnnotations;
using RentVacation.Dealers.Data.Models;

using static RentVacation.Dealers.Data.DataConstants.Apartament;
using static RentVacation.Dealers.Data.DataConstants.Options;

namespace RentVacation.Dealers.Models.Apartaments
{
    public class ApartamentInputModel
    {
        [Required]
        [MinLength(MinInformationLength)]
        [MaxLength(MaxInformationLength)]
        public string Information { get; set; }

        public int Category { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Range(0, int.MaxValue)]
        public decimal PricePerDay { get; set; }

        public bool HasClimateControl { get; set; }

        [Range(MinNumberOfBeds, MaxNumberOfBeds)]
        public int NumberOfBeds { get; set; }

        [EnumDataType(typeof(Floor))]
        public Floor Floor { get; set; }
    }
}
