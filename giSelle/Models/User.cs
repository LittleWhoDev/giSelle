using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace giSelle.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }

        [Required]
        public virtual Cart Cart { get; set; }
        public int CartId { get; set; }
    }
}