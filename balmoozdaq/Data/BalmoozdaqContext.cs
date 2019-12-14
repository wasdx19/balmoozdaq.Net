using System;
using balmoozdaq.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Data
{
    public class BalmoozdaqContext:IdentityDbContext
    {
        public BalmoozdaqContext(DbContextOptions<BalmoozdaqContext> options):base(options)
        {
        }

        public DbSet<Center> Center { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseTime> CourseTime { get; set; }
        public DbSet<CourseType> CourseType { get; set; }
        public DbSet<Weekday> Weekday { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //one-to-one  {Course-CourseTime}
            modelBuilder.Entity<Course>()
                .HasOne(c => c.CourseTime)
                .WithOne(ct => ct.Course)
                .HasForeignKey<CourseTime>(ct => ct.CourseId);

            //one-to-many {Center-Course; CourseType-Course; Weekday-CourseTime}
            modelBuilder.Entity<CourseTime>()
                .HasOne(ct => ct.Weekday)
                .WithMany(w => w.CourseTimeList);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Center)
                .WithMany(cn => cn.CourseList);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.CourseType)
                .WithMany(ct => ct.CourseList);
        }
    }
}
