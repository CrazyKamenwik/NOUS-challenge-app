using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NOUS_challenge_app.DAL.Entities;

namespace NOUS_challenge_app.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CleaningPlanEntity> CleaningPlan { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var options = new DbContextOptionsBuilder<AppDbContext>()
        //        .UseInMemoryDatabase("CleaningPlan")
        //        .Options;
        //}


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<CleaningPlanEntity>().HasData(new
        //    {
        //        Id = Guid.NewGuid(),
        //        Title = "Cum zone cleaning",
        //        CustomerId = 322,
        //        Description = "Clean cum zone after party",
        //        CreatedAt = DateTime.Now
        //    });
        //}
    }
}