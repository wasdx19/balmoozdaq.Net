using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using balmoozdaq.Data;
using balmoozdaq.Models;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Repositories
{
    public class CourseTimeRepo:ICourseTimeRepo
    {
        readonly BalmoozdaqContext _context;

        public CourseTimeRepo(BalmoozdaqContext context)
        {
            _context = context;
        }

        public void Add(CourseTime courseTime)
        {
            _context.Add(courseTime);
        }

        public void Delete(CourseTime courseTime)
        {
            _context.Remove(courseTime);
        }

        public bool Exist(int id)
        {
            return _context.CourseTime.Any(c => c.Id == id);
        }

        public Task<List<CourseTime>> GetAll()
        {
            return _context.CourseTime.ToListAsync();
        }

        public DbSet<Course> GetCourse()
        {
            return _context.Course;
        }

        public Task<CourseTime> GetDetail(int? id)
        {
            return _context.CourseTime.FirstOrDefaultAsync(c => c.Id == id);
        }

        public DbSet<Weekday> GetWeekday()
        {
            return _context.Weekday;
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(CourseTime courseTime)
        {
            _context.Update(courseTime);
        }
    }
}
