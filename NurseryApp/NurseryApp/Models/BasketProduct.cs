using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models
{
    public class BasketProduct
    {
        public string UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public Product Product {get; set;}

    }
}
