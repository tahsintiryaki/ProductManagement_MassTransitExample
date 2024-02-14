using MassTransit;
using ProductManagement.MessageContracts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.MessageContracts.Consumers
{
    public class ProductRegistrationCommandConsumer : IConsumer<IProductRegistrationCommand>
    {
        public async Task Consume(ConsumeContext<IProductRegistrationCommand> context)
        {
            Console.WriteLine($"{context.Message.ProductName} isimli ürün :");
            Console.WriteLine($"Veritabanına kayıt edilmiştir.");
            Console.WriteLine($"Facebook'ta yayınlanacaktır.");
            Console.WriteLine($"Instagram'da yayınlanacaktır.");
            Console.WriteLine("*********************");
        }
    }
}
