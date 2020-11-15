using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace giSelle.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        
        [Required]
        public bool HasQuantity { get; set; }
        public int Quantity { get; set; }
        // Price expressed in monetary units (smallest possible)
        // For example 100.23 RON means a price of 10023 BANI, BANI being the smallest MU possible
        [Required]
        public int PriceInMU { get; set; } 
        [Required]
        public string Currency { get; set; }

        // TODO: photo

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}