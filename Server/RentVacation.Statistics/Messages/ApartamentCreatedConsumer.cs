using MassTransit;
using RentVacation.Common.Messages.Dealers;
using RentVacation.Statistics.Services.TotalStatistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentVacation.Statistics.Messages
{
    public class ApartamentCreatedConsumer : IConsumer<ApartamentCreatedMessage>
    {
        private readonly ITotalStatisticsService statisticsService;

        public ApartamentCreatedConsumer(ITotalStatisticsService service) => statisticsService = service;

        public async Task Consume(ConsumeContext<ApartamentCreatedMessage> context)
        {
            var message = context.Message;

            await this.statisticsService.IncreaseApartaments();
        }
    }
}
