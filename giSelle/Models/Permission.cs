using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace giSelle.Models
{
    public class Permission
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}