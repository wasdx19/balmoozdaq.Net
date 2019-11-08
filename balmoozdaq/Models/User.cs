using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace balmoozdaq.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }

        public EducationCenter EducationCenter { get; set; }

        public Role Role { get; set; }

        public List<CenterCourse> CenterCourses { get; set; }

    }
}
