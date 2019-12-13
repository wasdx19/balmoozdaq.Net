using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using balmoozdaq.Models;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Repositories
{
    public interface ICenterRepo
    {
        void Add(Center center);
        void Update(Center center);
        void Delete(Center center);
        Task Save();
        Task<List<Center>> GetAll();
        Task<Center> GetDetail(int? id);
        bool Exist(int id);
        DbSet<Course> GetCourse();
    }
}
