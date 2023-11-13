using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next(); // wait for the action to be completed
            
            if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return; // if user is not authenticated, do nothing

            var userId = resultContext.HttpContext.User.GetUserId();

            var repo = resultContext.HttpContext.RequestServices.GetRequiredService<IUserRepository>();

            var user = await repo.GetUserByIdAsync(int.Parse(userId)); // get the user from the repo

            user.LastActive = DateTime.UtcNow; // set the last active property to now

            await repo.SaveAllAsync(); // save the changes
        }
    }
}