using MassTransit;
using RentVacation.Common.Messages.Dealers;
using RentVacation.Schedule.Services;
using System.Threading.Tasks;

namespace RentVacation.Schedule.Messages
{
    public class ApartamentUpdatedConsumer : IConsumer<ApartamentUpdatedMessage>
    {
        private readonly IRentedApartamentService rentedCars;

        public ApartamentUpdatedConsumer(IRentedApartamentService rentedCars) 
            => this.rentedCars = rentedCars;

        public async Task Consume(ConsumeContext<ApartamentUpdatedMessage> context)
            => await this.rentedCars.UpdateInformation(
                context.Message.ApartamentId,
                context.Message.Information);
    }
}
