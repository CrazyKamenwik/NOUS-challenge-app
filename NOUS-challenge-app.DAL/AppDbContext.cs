using Microsoft.EntityFrameworkCore;
using NOUS_challenge_app.DAL.Entities;
using System;
using System.Linq;

namespace NOUS_challenge_app.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CleaningPlanEntity> CleaningPlan { get; set; }
    }
}