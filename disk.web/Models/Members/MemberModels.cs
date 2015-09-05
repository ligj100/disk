using System;
using System.ComponentModel.DataAnnotations;
using disk.web.Validators.Member;
using disk.Web.Framework.Mvc;
using FluentValidation.Attributes;

namespace disk.web.Models.Members
{
    [Validator(typeof(MemberValidator))]
    public partial class MemberModels:BaseDiskModel
    {
        
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name="用户名")]
        public string UName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="密码")]
        public string Pwd { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="重复密码")]
        public string RePwd { get; set; }

        [Display(Name="邮箱")]
        public string Email { get; set; }

        [Display(Name="手机号")]
        public string Mobile { get; set; }

        
        [Display(Name="推荐人")]
        public string AffiliateName { get; set; }

        [Display(Name="激活状态")]
        public bool Active { get; set; }

        [Display(Name="是否删除")]
        public bool Deleted { get; set; }

        [Display(Name="上次登录IP")]
        public string LastIpAddress { get; set; }

        [Display(Name="创建时间")]
        public DateTime Created { get; set; }

        [Display(Name="上次登录时间")]
        public DateTime? LastLoginDate { get; set; }
    }
}