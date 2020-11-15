using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace giSelle.Models
{
    public class Cart
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}