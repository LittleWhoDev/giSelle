using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace giSelle.Models
{
    public class InvoiceLine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        // A little bit of redundancy to overcome the problem of 
        // changing the product price/properties
        [Required]
        public bool HasQuantity { get; set; }
        public int Quantity { get; set; }
        [Required]
        public int PriceInMU { get; set; }
        [Required]
        public int Total { get; set; }
    }
}