using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace giSelle.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(256)]
        public string Name { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}