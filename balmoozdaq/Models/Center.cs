using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using balmoozdaq.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace balmoozdaq.Models
{
    public class Center: IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [PhoneNumberAttribute("11", "The phone number must contain 11 numbers")]
        public string Phone { get; set; }
        public string Address { get; set; }

        [Remote(action: "CheckUrl", controller: "Center")]
        public string Imgurl { get; set; }

        public List<Course> CourseList { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name==null)
            {
                yield return new ValidationResult("You must fill the Education center name");
            }
        }
    }
}
