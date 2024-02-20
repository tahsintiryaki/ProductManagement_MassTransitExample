using MassTransit;
using Microsoft.AspNetCore.SignalR.Client;
using ProductManagement.MessageContracts.Events;
using ProductManagement.MessageContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.MessageContracts.Consumers
{
    public class ProductNotificationEventConsumer : IConsumer<IProductEvent>
    {
        

        public async Task Consume(ConsumeContext<IProductEvent> context)
        {
            Console.WriteLine($"{context.Message.ProductName} isimli ürün yayınlanarak müşteriler bilgilendirilmiştir.");

            Console.WriteLine($"{context.Message.ProductName} isimli ürün yayınlanarak müşteriler bilgilendirilmiştir.");
            //await _dispatcher.SendMessageAsync((Product)context.Message);
            HubConnection connection = new HubConnectionBuilder().WithUrl("https://localhost:7173/notificationhub").Build();
            await connection.StartAsync();

            await connection.InvokeAsync("SendMessageAsync", context.Message);

            await connection.StopAsync();
        }
    }
}
