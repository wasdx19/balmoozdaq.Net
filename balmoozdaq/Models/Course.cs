using System;
namespace balmoozdaq.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public CourseTime CourseTime { get; set; }

        public int CourseTypeId { get; set; }
        public CourseType CourseType { get; set; }

        public int CenterId { get; set; }
        public Center Center { get; set; }
    }
}
