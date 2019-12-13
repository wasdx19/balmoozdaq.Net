using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using balmoozdaq.Data;
using balmoozdaq.Models;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Repositories
{
    public class WeekdayRepo:IWeekdayRepo
    {
        readonly BalmoozdaqContext _context;
        public WeekdayRepo(BalmoozdaqContext context)
        {
            _context = context;
        }

        public void Add(Weekday weekday)
        {
            _context.Add(weekday);
        }

        public void Delete(Weekday weekday)
        {
            _context.Remove(weekday);
        }

        public bool Exist(int id)
        {
            return _context.Weekday.Any(c => c.Id == id);
        }

        public Task<List<Weekday>> GetAll()
        {
            return _context.Weekday.ToListAsync();
        }

        public DbSet<CourseTime> GetCourseTime()
        {
            return _context.CourseTime;
        }

        public Task<Weekday> GetDetail(int? id)
        {
            return _context.Weekday.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Weekday weekday)
        {
            _context.Update(weekday);
        }
    }
}
