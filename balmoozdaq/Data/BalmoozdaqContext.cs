using System;
using balmoozdaq.Models;
using Microsoft.EntityFrameworkCore;

namespace balmoozdaq.Data
{
    public class BalmoozdaqContext:DbContext
    {
        public BalmoozdaqContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<EducationCenter> EducationCenters { get; set; }
        public DbSet<CourseTime> CourseTimes { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }
        public DbSet<CenterCourse> CenterCourses { get; set; }
        public DbSet<Role> Roles { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to one
            modelBuilder.Entity<User>()
                .HasOne(u => u.EducationCenter)
                .WithOne(e => e.User)
                .HasForeignKey<EducationCenter>(e=>e.UserId);

            //one to many
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role);

            modelBuilder.Entity<WeekDay>()
                .HasMany(w => w.CourseTimes)
                .WithOne(c => c.WeekDay);

            modelBuilder.Entity<CenterCourse>()
                .HasMany(c => c.WeekDay)
                .WithOne(w => w.CenterCourse);

            //many to many
            modelBuilder.Entity<CenterCourse>()
                .HasKey(c => new { c.EduCenterId, c.CourseId, c.UserId});

            modelBuilder.Entity<CenterCourse>()
                .HasOne(c => c.Course)
                .WithMany(c => c.CenterCourses)
                .HasForeignKey(cc => cc.CourseId);

            modelBuilder.Entity<CenterCourse>()
                .HasOne(cc => cc.EducationCenter)
                .WithMany(ec => ec.CenterCourses)
                .HasForeignKey(cc => cc.EduCenterId);

            modelBuilder.Entity<CenterCourse>()
                .HasOne(cc => cc.User)
                .WithMany(u => u.CenterCourses)
                .HasForeignKey(cc => cc.UserId);
        }
    }
}
