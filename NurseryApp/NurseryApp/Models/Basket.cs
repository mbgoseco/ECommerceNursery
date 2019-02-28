using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models
{
    public class Basket
    {
        public int ID { get; set; }
        public string UserID { get; set; }

        public IEnumerable<BasketProduct> BasketProducts { get; set; }
    }
}
