using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using balmoozdaq.Data;
using balmoozdaq.Models;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Repositories
{
    public class CourseRepo:ICourseRepo
    {
        readonly BalmoozdaqContext _context;

        public CourseRepo(BalmoozdaqContext context)
        {
            _context = context;
        }

        public void Add(Course course)
        {
            _context.Add(course);
        }

        public void Delete(Course course)
        {
            _context.Remove(course);
        }

        public bool Exist(int id)
        {
            return _context.Course.Any(c => c.Id == id);
        }

        public Task<List<Course>> GetAll()
        {
            return _context.Course.ToListAsync();
        }

        public DbSet<Center> GetCenter()
        {
            return _context.Center;
        }

        public DbSet<CourseTime> GetCourseTime()
        {
            return _context.CourseTime;
        }

        public DbSet<CourseType> GetCourseType()
        {
            return _context.CourseType;
        }

        public Task<Course> GetDetail(int? id)
        {
            return _context.Course.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Course course)
        {
            _context.Update(course);
        }
    }
}
