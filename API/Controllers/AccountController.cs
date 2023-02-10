using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class AccountController : BaseApiController
    {
        public AccountController(DataContext context) : base(context)
        {
        }

        [HttpPost("register")]//POST:api/account/register
        public async Task<ActionResult<AppUser>> register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
            using var mac = new HMACSHA512();

            var user = new AppUser
            {

                UserName = registerDto.Username.ToLower(),
                PasswordHash = mac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = mac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
