using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace balmoozdaq.Models
{
    public class EducationCenter
    {
        [Key]
        public int Id { get; set; }
        public string EduCenterName { get; set; }
        public string EduCenterDesc { get; set; }
        public string EduCenterPhone { get; set; }
        public string EduCenterAddress { get; set; }
        public string EduCenterImgUrl { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public List<CenterCourse> CenterCourses { get; set; }
    }
}
