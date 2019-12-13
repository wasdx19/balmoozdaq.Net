using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using balmoozdaq.Data;
using balmoozdaq.Models;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Repositories
{
    public class CenterRepo:ICenterRepo
    {
        readonly BalmoozdaqContext _context;

        public CenterRepo(BalmoozdaqContext context)
        {
            _context = context;
        }

        public void Add(Center center)
        {
            _context.Add(center);
        }

        public void Delete(Center center)
        {
            _context.Remove(center);
        }

        public bool Exist(int id)
        {
            return _context.Center.Any(c => c.Id == id);
        }

        public Task<List<Center>> GetAll()
        {
            return _context.Center.ToListAsync();
        }

        public DbSet<Course> GetCourse()
        {
            return _context.Course;
        }

        public Task<Center> GetDetail(int? id)
        {
            return _context.Center.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Center center)
        {
            _context.Update(center);
        }
    }
}
