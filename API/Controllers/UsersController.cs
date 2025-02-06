using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController(DataContext context) : BaseApiController 
{
    [AllowAnonymous] // worth remembering this cannot be top level and later changed to [Authorized] - can cause issues 
    [HttpGet] 
    public async Task<ActionResult<IEnumerable<AppUser>>>  GetUsers(){
        var users = await context.Users.ToListAsync();
        return users;
    }

    [Authorize]
    [HttpGet("{id:int}")]   // route - /api/users/id
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}
