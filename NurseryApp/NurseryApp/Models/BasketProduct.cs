using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models
{
    public class BasketProduct
    {
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter a quantity between 1 and 1000.")]
        public int Quantity { get; set; }

        public Product Product {get; set;}

    }
}
