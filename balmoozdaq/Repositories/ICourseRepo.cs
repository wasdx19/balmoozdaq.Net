using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using balmoozdaq.Models;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Repositories
{
    public interface ICourseRepo
    {
        void Add(Course course);
        void Update(Course course);
        void Delete(Course course);
        Task Save();
        Task<List<Course>> GetAll();
        Task<Course> GetDetail(int? id);
        bool Exist(int id);
        DbSet<Center> GetCenter();
        DbSet<CourseTime> GetCourseTime();
        DbSet<CourseType> GetCourseType();
    }
}
