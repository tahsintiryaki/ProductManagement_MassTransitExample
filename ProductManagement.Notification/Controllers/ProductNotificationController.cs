using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.MessageContracts;
using ProductManagement.MessageContracts.Consumers;
using ProductManagement.MessageContracts.Hubs;

namespace ProductManagement.Notification.Controllers
{
    public class ProductNotificationController : Controller
    {
        private readonly IHubNotificationDispatcher _notificationDispatcher;

        public ProductNotificationController(IHubNotificationDispatcher notificationDispatcher)
        {
            _notificationDispatcher = notificationDispatcher;
        }

        public async Task<IActionResult> Index()
        {

            var bus = BusConfigurator.ConfigureBus(factory =>
            {
                factory.ReceiveEndpoint(RabbitMqConstants.NotificationServiceQueue, endpoint =>
                {
                   
                    endpoint.Consumer(() => new ProductNotificationEventConsumer(_notificationDispatcher));
                });
            });

            await bus.StartAsync();
            return View();
        }
    }
}
