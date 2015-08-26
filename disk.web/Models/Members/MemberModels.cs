using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace disk.web.Models.Members
{
    public class MemberModels
    {
        [Required]
        [Display(Name = "Member name")]
        public string Name { get; set; }
    }
}