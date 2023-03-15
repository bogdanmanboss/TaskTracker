using Microsoft.AspNetCore.Mvc;
using TaskTracker.API.Core.Controllers;
using TaskTracker.Sql.Library.Services;

namespace TaskTracker.API.Controllers
{
    public class TaskTrackerWebApiController : TaskTrackerApiControllerBase
    {
        private readonly UserService UserService;

        public TaskTrackerWebApiController(
            UserService userService
            )
        {
            UserService = userService;
        }

        public override async Task<ActionResult<ICollection<User>>> UserGetMany()
        {
            var users = await UserService.GetMany();
            return new OkObjectResult(users);
        }
    }
}
