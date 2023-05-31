using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultipleDbContexts.Data;
using MultipleDbContexts.Models;

namespace MultipleDbContexts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly UserDbContext _userDbContext;
        private readonly CharacterDbContext _characterDbContext;

        public CharacterController(UserDbContext userDbContext, CharacterDbContext characterDbContext)
        {
            _userDbContext = userDbContext;
            _characterDbContext = characterDbContext;
        }

        public async Task<ActionResult<UserResponseDto>> GetCharacters(int userId) 
        {
            var user = await _userDbContext.Users.FindAsync(userId);
            if (user == null)
            {
                //throw new NullReferenceException("Not found");
                return default(UserResponseDto);
            }
            var characters = await _characterDbContext.Characters.Where(x => x.UserId == user.Id)
                .ToListAsync();

            var result = new UserResponseDto(user.Id, user.Name, characters);

            return Ok(result);
        }
    }
}
