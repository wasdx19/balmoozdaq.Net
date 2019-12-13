using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using balmoozdaq.Models;
using balmoozdaq.Repositories;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Services
{
    public class CourseService
    {
        private readonly ICourseRepo _repo;

        public CourseService(ICourseRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Course>> GetCourse()
        {
            return await _repo.GetAll();

        }


        public async Task<Course> DetailsCourse(int? id)
        {
            return await _repo.GetDetail(id);

        }

        public bool CourseExist(int id)
        {
            return _repo.Exist(id);

        }

        public async Task AddAndSave(Course course)
        {
            _repo.Add(course);
            await _repo.Save();
        }

        public async Task Update(Course course)
        {
            _repo.Update(course);
            await _repo.Save();

        }

        public async Task Delete(Course course)
        {
            _repo.Delete(course);
            await _repo.Save();

        }

        public DbSet<Center> GetCenter()
        {
            return _repo.GetCenter();
        }

        public DbSet<CourseTime> GetCourseTime()
        {
            return _repo.GetCourseTime();
        }

        public DbSet<CourseType> GetCourseType()
        {
            return _repo.GetCourseType();
        }

    }
}
