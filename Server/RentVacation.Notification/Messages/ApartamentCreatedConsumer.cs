using MassTransit;
using Microsoft.AspNetCore.SignalR;
using RentVacation.Common.Messages.Dealers;
using RentVacation.Notification.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentVacation.Notification.Messages
{
    public class ApartamentCreatedConsumer : IConsumer<ApartamentCreatedMessage>
    {
        private IHubContext<NotificationHub> hub;

        public ApartamentCreatedConsumer(IHubContext<NotificationHub> hub) => this.hub = hub;

        public async Task Consume(ConsumeContext<ApartamentCreatedMessage> context)
        {
            await this.hub.Clients.Groups("SpamGroup").SendAsync($"ReceiveNotification", $"New Apartament just added!");
        }
    }
}
