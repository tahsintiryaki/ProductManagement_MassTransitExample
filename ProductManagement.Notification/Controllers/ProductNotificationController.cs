using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.MessageContracts;
using ProductManagement.MessageContracts.Consumers;

namespace ProductManagement.Notification.Controllers
{
    public class ProductNotificationController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var bus = BusConfigurator.ConfigureBus(factory =>
            {
                factory.ReceiveEndpoint(RabbitMqConstants.NotificationServiceQueue, endpoint =>
                {
                    endpoint.Consumer<ProductNotificationEventConsumer>();
                });
            });

            await bus.StartAsync();
            await Task.Run(() => Console.ReadLine());
            await bus.StopAsync();
            return View();
        }
    }
}
