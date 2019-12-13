using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using balmoozdaq.Models;
using balmoozdaq.Repositories;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Services
{
    public class CourseTimeService
    {
        private readonly ICourseTimeRepo _repo;

        public CourseTimeService(ICourseTimeRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<CourseTime>> GetCourseTime()
        {
            return await _repo.GetAll();

        }


        public async Task<CourseTime> DetailsCourseTime(int? id)
        {
            return await _repo.GetDetail(id);

        }

        public bool CourseTimeExist(int id)
        {
            return _repo.Exist(id);

        }

        public async Task AddAndSave(CourseTime courseTime)
        {
            _repo.Add(courseTime);
            await _repo.Save();
        }

        public async Task Update(CourseTime courseTime)
        {
            _repo.Update(courseTime);
            await _repo.Save();

        }

        public async Task Delete(CourseTime courseTime)
        {
            _repo.Delete(courseTime);
            await _repo.Save();

        }

        public DbSet<Course> GetCourse()
        {
            return _repo.GetCourse();
        }

        public DbSet<Weekday> GetWeekday()
        {
            return _repo.GetWeekday();
        }
    }
}
