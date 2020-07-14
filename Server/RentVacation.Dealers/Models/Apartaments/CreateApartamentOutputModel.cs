namespace RentVacation.Dealers.Models.Apartaments
{
    public class CreateApartamentOutputModel
    {
        public CreateApartamentOutputModel(int apartamentId)
            => this.ApartamentId = apartamentId;

        public int ApartamentId { get; }
    }
}
