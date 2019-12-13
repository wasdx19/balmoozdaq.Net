using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using balmoozdaq.Models;
using balmoozdaq.Repositories;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Services
{
    public class WeekdayService
    {
        private readonly IWeekdayRepo _repo;

        public WeekdayService(IWeekdayRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Weekday>> GetWeekday()
        {
            return await _repo.GetAll();

        }


        public async Task<Weekday> DetailsWeekday(int? id)
        {
            return await _repo.GetDetail(id);

        }

        public bool WeekdayExist(int id)
        {
            return _repo.Exist(id);

        }

        public async Task AddAndSave(Weekday weekday)
        {
            _repo.Add(weekday);
            await _repo.Save();
        }

        public async Task Update(Weekday weekday)
        {
            _repo.Update(weekday);
            await _repo.Save();

        }

        public async Task Delete(Weekday weekday)
        {
            _repo.Delete(weekday);
            await _repo.Save();

        }

        public DbSet<CourseTime> GetCourseTime()
        {
            return _repo.GetCourseTime();
        }
    }
}
