using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using balmoozdaq.Models;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Repositories
{
    public interface ICourseTimeRepo
    {
        void Add(CourseTime courseTime);
        void Update(CourseTime courseTime);
        void Delete(CourseTime courseTime);
        Task Save();
        Task<List<CourseTime>> GetAll();
        Task<CourseTime> GetDetail(int? id);
        bool Exist(int id);
        DbSet<Weekday> GetWeekday();
        DbSet<Course> GetCourse();
    }
}
