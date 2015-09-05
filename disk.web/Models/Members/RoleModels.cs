using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using disk.web.Validators.Member;
using FluentValidation.Attributes;

namespace disk.web.Models.Members
{
    [Validator(typeof(RoleValidator))]
    public class RoleModels
    {
        [Display(Name = "角色名称")]
        public string Name { get; set; }

        [Display(Name = "角色描述")]
        public string Desc { get; set; }

    }
}