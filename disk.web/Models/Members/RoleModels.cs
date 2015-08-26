using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace disk.web.Models.Members
{
    public class RoleModels
    {
        [Required]
        [Display(Name = "Role name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Role Desc")]
        public string Desc { get; set; }
    }
}