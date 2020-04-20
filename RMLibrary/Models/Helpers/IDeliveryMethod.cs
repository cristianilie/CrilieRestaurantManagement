using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLibrary.Models.Helpers
{
    public interface IDeliveryMethod
    {
        int Id { get; set; }

        string Name { get; set; }

        string DeliveryAdress { get; set; }
    }
}
