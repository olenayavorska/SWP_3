using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public virtual List<CartLine> cartLines { get; set; }
        public virtual ShippingDetails shippingDetails { get; set; }
    }
}