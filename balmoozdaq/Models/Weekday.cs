using System;
using System.Collections.Generic;

namespace balmoozdaq.Models
{
    public class Weekday
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CourseTime> CourseTimeList { get; set; }
    }
}
