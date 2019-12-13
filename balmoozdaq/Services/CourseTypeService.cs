using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using balmoozdaq.Models;
using balmoozdaq.Repositories;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Services
{
    public class CourseTypeService
    {
        private readonly ICourseTypeRepo _repo;

        public CourseTypeService(ICourseTypeRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<CourseType>> GetCourseType()
        {
            return await _repo.GetAll();

        }


        public async Task<CourseType> DetailsCourseType(int? id)
        {
            return await _repo.GetDetail(id);

        }

        public bool CourseTypeExist(int id)
        {
            return _repo.Exist(id);

        }

        public async Task AddAndSave(CourseType courseType)
        {
            _repo.Add(courseType);
            await _repo.Save();
        }

        public async Task Update(CourseType courseType)
        {
            _repo.Update(courseType);
            await _repo.Save();

        }

        public async Task Delete(CourseType courseType)
        {
            _repo.Delete(courseType);
            await _repo.Save();

        }

        public DbSet<Course> GetCourses()
        {
            return _repo.GetCourses();
        }


    }
}
