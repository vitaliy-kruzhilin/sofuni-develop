using MassTransit;
using RentVacation.Common.Messages.Dealers;
using RentVacation.Statistics.Services.TotalStatistics;
using System.Threading.Tasks;

namespace RentVacation.Statistics.Messages
{
    public class ApartamentCreatedConsumer : IConsumer<ApartamentCreatedMessage>
    {
        private readonly ITotalStatisticsService statisticsService;

        public ApartamentCreatedConsumer(ITotalStatisticsService service) => statisticsService = service;

        public async Task Consume(ConsumeContext<ApartamentCreatedMessage> context) => await this.statisticsService.IncreaseApartaments();
    }
}
