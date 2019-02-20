using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models
{
    public class Product
    {
        //properties
        public int ID { get; set; }
        public string Name { get; set; }
        public PlantType Type { get; set; }

        public enum PlantType { Tree, Shrub, Flower, Houseplant };
    }
}
