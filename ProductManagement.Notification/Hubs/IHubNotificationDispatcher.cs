using ProductManagement.MessageContracts.Models;

namespace ProductManagement.MessageContracts.Hubs
{
    public interface IHubNotificationDispatcher
    {
        Task SendMessageAsync(Product product);
    }
}
