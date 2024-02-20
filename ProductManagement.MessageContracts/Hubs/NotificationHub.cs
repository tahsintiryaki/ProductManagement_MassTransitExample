using Microsoft.AspNetCore.SignalR;
using ProductManagement.MessageContracts.Models;

namespace ProductManagement.Notification.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendMessageAsync(Product product)
        {
            await Clients.All.SendAsync("receiveProductNotification", product);
        }
    }
}
