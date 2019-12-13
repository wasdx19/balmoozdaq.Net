using System;
namespace balmoozdaq.Models
{
    public class CourseTime
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public int WeekdayId { get; set; }
        public Weekday Weekday { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
