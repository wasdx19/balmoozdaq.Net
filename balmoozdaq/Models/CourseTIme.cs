using System;
using System.ComponentModel.DataAnnotations;

namespace balmoozdaq.Models
{
    public class CourseTime
    {
        [Key]
        public int Id { get; set; }
        public string CourseStartTime { get; set; }
        public string CourseEndTime { get; set; }

        public WeekDay WeekDay { get; set; }
    }
}
