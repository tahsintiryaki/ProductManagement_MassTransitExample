using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.MessageContracts.Events
{
    public interface IProductEvent
    {
        string ProductName { get; set; }
        int Quantity { get; set; }
    }
}
