using MassTransit;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using ProductManagement.MessageContracts.Events;
using ProductManagement.MessageContracts.Hubs;
using ProductManagement.MessageContracts.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.MessageContracts.Consumers
{
    public class ProductNotificationEventConsumer : IConsumer<IProductEvent>
    {
        private readonly IHubNotificationDispatcher _hubNotificationDispatcher;

        public ProductNotificationEventConsumer(IHubNotificationDispatcher hubNotificationDispatcher)
        {
            _hubNotificationDispatcher = hubNotificationDispatcher;
        }

        public async Task Consume(ConsumeContext<IProductEvent> context)
        {
            Console.WriteLine($"{context.Message.ProductName} isimli ürün yayınlanarak müşteriler bilgilendirilmiştir.");

            Console.WriteLine($"{context.Message.ProductName} isimli ürün yayınlanarak müşteriler bilgilendirilmiştir.");


            await _hubNotificationDispatcher.SendMessageAsync(new Product()
            {
                ProductName = context.Message.ProductName,
                Quantity = context.Message.Quantity
            });

        }
    }
}
