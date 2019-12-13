using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using balmoozdaq.Models;
using balmoozdaq.Repositories;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Services
{
    public class CenterService
    {
        private readonly ICenterRepo _repo;

        public CenterService(ICenterRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Center>> GetCenter()
        {
            return await _repo.GetAll();
            
        }

    
        public async Task<Center> DetailsCenter(int? id)
        {
            return await _repo.GetDetail(id);
          
        }
       
        public bool CenterExis(int id)
        {
            return _repo.Exist(id);
           
        }
    
        public async Task AddAndSave(Center center)
        {
            _repo.Add(center);
            await _repo.Save();
        }

        public async Task Update(Center center)
        {
            _repo.Update(center);
            await _repo.Save();

        }

        public async Task Delete(Center center)
        {
            _repo.Delete(center);
            await _repo.Save();

        }

        public DbSet<Course> GetCourse()
        {
            return _repo.GetCourse();
        }


    }
}
