using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using balmoozdaq.Models;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Repositories
{
    public interface ICourseTypeRepo
    {
        void Add(CourseType courseType);
        void Update(CourseType courseType);
        void Delete(CourseType courseType);
        Task Save();
        Task<List<CourseType>> GetAll();
        Task<CourseType> GetDetail(int? id);
        bool Exist(int id);
        DbSet<Course> GetCourses();
    }
}
