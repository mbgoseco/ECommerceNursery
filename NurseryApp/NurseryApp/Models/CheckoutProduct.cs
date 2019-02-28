using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models
{
    public class CheckoutProduct
    {
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
