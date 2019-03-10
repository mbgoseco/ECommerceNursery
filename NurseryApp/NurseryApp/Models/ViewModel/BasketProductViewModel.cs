using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static NurseryApp.Models.Product;

namespace NurseryApp.Models.ViewModel
{
    public class BasketProductViewModel
    {
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter a quantity between 1 and 1000.")]
        public int Quantity { get; set; }
        public string Name { get; set; }
        public PlantType Type { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
        public string Sku { get; set; }
        public bool Bulk { get; set; }
        public decimal ProductTotal { get; set; }
        public decimal Total { get; set; }
    }
}
