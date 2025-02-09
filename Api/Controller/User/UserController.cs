using Business.Interfaces.User;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller.User
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAllUsers")]
        public async Task<ActionResult<IEnumerable<UserDAL>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("getUserById/{id}")]
        public async Task<ActionResult<UserDAL>> GetByUsersId(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost("createUser")]
        public async Task<ActionResult> CreateUsers([FromBody] UserDAL usuario)
        {
            await _userService.AddUserAsync(usuario);
            return CreatedAtAction(nameof(GetByUsersId), new { id = usuario.Id }, usuario);
        }

        [HttpPut("updateUser/{id}")]
        public async Task<ActionResult> UpdateUsers(int id, [FromBody] UserDAL usuario)
        {
            if (id != usuario.Id)
                return BadRequest();

            await _userService.UpdateUserAsync(usuario);
            return NoContent();
        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }

}
