using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace balmoozdaq.Models
{
    public class CenterCourse
    {
        [Key]
        public int Id { get; set; }

        public int EduCenterId { get; set; }
        [ForeignKey("EducationCenterId")]
        public EducationCenter EducationCenter { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public string CenterCourseDesc { get; set; }

        public List<WeekDay> WeekDay { get; set; }

    }
}
