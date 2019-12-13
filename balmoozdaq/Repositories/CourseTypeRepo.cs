using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using balmoozdaq.Data;
using balmoozdaq.Models;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Repositories
{
    public class CourseTypeRepo:ICourseTypeRepo
    {
        readonly BalmoozdaqContext _context;

        public CourseTypeRepo(BalmoozdaqContext context)
        {
            _context = context;
        }

        public void Add(CourseType courseType)
        {
            _context.Add(courseType);
        }

        public void Delete(CourseType courseType)
        {
            _context.Remove(courseType);
        }

        public bool Exist(int id)
        {
            return _context.CourseType.Any(c => c.Id == id);
        }

        public Task<List<CourseType>> GetAll()
        {
            return _context.CourseType.ToListAsync();
        }

        public DbSet<Course> GetCourses()
        {
            return _context.Course;
        }

        public Task<CourseType> GetDetail(int? id)
        {
            return _context.CourseType.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(CourseType courseType)
        {
            _context.Update(courseType);
        }

    }
}
