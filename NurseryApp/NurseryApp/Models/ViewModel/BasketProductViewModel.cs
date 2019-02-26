using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NurseryApp.Models.Product;

namespace NurseryApp.Models.ViewModel
{
    public class BasketProductViewModel
    {
        public string UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public PlantType Type { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
        public string Sku { get; set; }
        public bool Bulk { get; set; }
    }
}
