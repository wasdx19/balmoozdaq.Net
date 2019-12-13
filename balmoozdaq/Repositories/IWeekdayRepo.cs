using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using balmoozdaq.Models;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Repositories
{
    public interface IWeekdayRepo
    {
        void Add(Weekday weekday);
        void Update(Weekday weekday);
        void Delete(Weekday weekday);
        Task Save();
        Task<List<Weekday>> GetAll();
        Task<Weekday> GetDetail(int? id);
        bool Exist(int id);
        DbSet<CourseTime> GetCourseTime();
    }
}
