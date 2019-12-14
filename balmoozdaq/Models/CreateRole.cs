using System;
using System.ComponentModel.DataAnnotations;

namespace balmoozdaq.Models
{
    public class CreateRole
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
