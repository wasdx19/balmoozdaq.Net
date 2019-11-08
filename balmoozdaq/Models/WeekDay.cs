using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace balmoozdaq.Models
{
    public class WeekDay
    {
        [Key]
        public int Id { get; set; }
        public string DayName { get; set; }

        public List<CourseTime> CourseTimes { get; set; }

        public CenterCourse CenterCourse { get; set; }
    }
}
