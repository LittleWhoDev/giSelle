using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace giSelle.Models
{
    public class Invoice
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Date { get; set; }

        [Required]
        public virtual User User { get; set; }
        public virtual ICollection<InvoiceLine> Lines { get; set; }
        [Required]
        public int Total { get; set; }
    }
}