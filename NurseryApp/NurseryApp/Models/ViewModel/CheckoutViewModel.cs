using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.ViewModel
{
    public class CheckoutViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string CC { get; set; }
        [Required]
        public int CVV { get; set; }
        [Required]
        [RegularExpression("^[0 - 9]{2}/[0-9]{2}$")]
        public string ExpirationDate { get; set; }
        [Required]
        public decimal Total { get; set; }

    }
}
