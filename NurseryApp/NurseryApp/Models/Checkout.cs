using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models
{
    public class Checkout
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }

        public IEnumerable<CheckoutProduct> CheckoutProducts { get; set; }
    }
}
