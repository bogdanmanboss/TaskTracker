using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.API.Core.Controllers;

namespace TaskTracker.Sql.Library.Services
{
    public class UserService
    {
        public TaskTrackerDbContext TaskTrackerDbContext { get; set; }

        public UserService(TaskTrackerDbContext taskTrackerDbContext) {
            TaskTrackerDbContext = taskTrackerDbContext;
        }

        public async Task<List<User>> GetMany()
        {
            return await TaskTrackerDbContext.Users.ToListAsync();
        }
    }
}
