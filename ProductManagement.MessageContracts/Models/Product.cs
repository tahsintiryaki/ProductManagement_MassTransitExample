using ProductManagement.MessageContracts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.MessageContracts.Models
{
    public class Product : IProductRegistrationCommand
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
