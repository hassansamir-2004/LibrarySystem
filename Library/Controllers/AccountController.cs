using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentValidation;
using Library.Data;
using Library.DTO;
using Library.Entities;
using Library.validition;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IPasswordHasher<User> hasher,LibraryDbContext context,IConfiguration config) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(userdto _userdto)
        {
            validator validations = new validator();
           var v= validations.Validate(_userdto);
            if(!v.Errors.Any())
            {
                User _user = new User
                {
                    name = _userdto.username,
                    email = _userdto.email,
                    phone=_userdto.phone
                };
                _user.passwordHash = hasher.HashPassword(_user, _userdto.Password);
                if(!context.users.Any())
                {
                    _user.isadmin = true;
                }
               await context.users.AddAsync(_user);
                await context.SaveChangesAsync();

            }
                return Ok(string.Join(",", v.Errors));
            
        }
        [HttpGet]
        public async Task<IActionResult> Login(string username,string password)
        {
            var U = await context.users.FirstOrDefaultAsync(x => x.name == username);
            if (U != null)
            {
                var check = hasher.VerifyHashedPassword(U, U.passwordHash, password);
                if (check == PasswordVerificationResult.Success)
                {
                    List<Claim> c = new List<Claim>();
                    c.Add(new Claim(ClaimTypes.NameIdentifier, U.id.ToString()));
                    if (U.isadmin)
                    { c.Add(new Claim(ClaimTypes.Role, "admin"));

                    }
                   
                    var k = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:secritkey"]));
                    SigningCredentials cred = new SigningCredentials(k, SecurityAlgorithms.HmacSha256);
                    var jwt = new JwtSecurityToken(claims: c,signingCredentials:cred,expires:DateTime.UtcNow.AddHours(1));
                    return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
                }
            }
            return Ok("password or username false");
        }
                    

    }
}
        
    

