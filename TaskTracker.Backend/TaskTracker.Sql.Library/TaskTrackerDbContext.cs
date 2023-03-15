using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.API.Core.Controllers;

namespace TaskTracker.Sql.Library
{
    public class TaskTrackerDbContext: IdentityDbContext
    {

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public string ConnectionString = "Server=DESKTOP-KUDIFV6;Database=TaskTracker_Db;Trusted_Connection=True;Encrypt=False";

        public TaskTrackerDbContext() { }

        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                // This should only happen when using without configuration in `Startup.cs` (`detnet ef`, Console Applications etc.)
                _ = options.UseSqlServer(ConnectionString);
            }
        }
    }
}
