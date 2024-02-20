using Microsoft.AspNetCore.SignalR;
using ProductManagement.MessageContracts.Models;
using ProductManagement.Notification.Hubs;

namespace ProductManagement.MessageContracts.Hubs
{
    public class HubNotificationDispatcher : IHubNotificationDispatcher
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public HubNotificationDispatcher(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(Product product)
        {
            await _hubContext.Clients.All.SendAsync("receiveProductNotification", product);
        }
    }
}
