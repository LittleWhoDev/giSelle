using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace giSelle.Models
{
    public class Product: ProductAttributes
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Categories = new HashSet<Category>();
        }

        [Key]
        public int Id { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }

    public class ProductAttributes
    {
        [Required(ErrorMessage = "Name is mandatory.")]
        public string Name { get; set; }

        public string Description { get; set; }
        public string SKU { get; set; }

        [Required]
        public bool HasQuantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be positive.")]
        public int Quantity { get; set; }

        // Price expressed in monetary units (smallest possible)
        // For example 100.23 RON means a price of 10023 BANI, BANI being the smallest MU possible
        [Range(0, int.MaxValue, ErrorMessage = "Price must be positive.")]
        public int PriceInMU { get; set; }

        [Required(ErrorMessage = "Currency is mandatory.")]
        [RegularExpression(@"^RON|EUR|USD$", ErrorMessage = "Unkown currency.")]
        [StringLength(5, ErrorMessage = "Currency name is too long.")]
        public string Currency { get; set; }

        // TODO: photo
    }

    public class CreateProductViewModel: ProductAttributes
    {
        public int[] CategoryIds { get; set; }
    }

    public class EditProductViewModel: ProductAttributes
    {
        [Required]
        public int Id { get; set; }

        public int[] CategoryIds { get; set; } 
    }
}